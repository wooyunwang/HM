using HM.Common_;
using HM.DTO;
using HM.Enum_;
using HM.Enum_.FacePlatform;
using HM.Face.Common_;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using HM.FacePlatform.UserControls;
using HM.FacePlatform.VO;
using HM.Form_;
using HM.Utils_;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.FacePlatform.Forms
{
    /// <summary>
    /// 本窗口不能使用RichTextBox，否则界面卡顿不正常
    /// </summary>
    public partial class FaceJobFrm : FrmBase
    {

        MaoFailedJobBLL _maoFailedJobBLL = new MaoFailedJobBLL();
        RegisterBLL _registerBLL = new RegisterBLL();
        MaoBLL _maoBLL = new MaoBLL();
        MaoBuildingBLL _maoBuildingBLL = new MaoBuildingBLL();
        UserBLL _userBLL = new UserBLL();
        UserHouseBLL _userHouseBLL = new UserHouseBLL();

        /// <summary>
        /// Obj在此代表是否有任务正在进行中
        /// </summary>
        ActionResult<bool> _actionResult = new ActionResult<bool>() { Obj = false };


        public FaceJobFrm()
        {
            InitializeComponent();
            //屏蔽关闭按钮
            this.ControlBox = false;
        }

        private void FaceJobFrm_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 基本的检查
        /// </summary>
        /// <param name="isForce">强制检查：只要一个有问题，则必定返回false</param>
        ///  <param name="user_uid">用户唯一标识，用于</param>
        /// <returns>返回的Obj中，为可用人脸一体机的列表</returns>
        public ActionResult<MaoCheckResult> BasicCheck(bool isForce = false, string user_uid = null, string house_code = null)
        {
            ActionResult<MaoCheckResult> ar = new ActionResult<MaoCheckResult>();
            ar.Obj = ar.Obj ?? new MaoCheckResult();
            var lstMao = GetSectionMao(user_uid, house_code);
            if (!lstMao.Any())
            {
                ar.IsSuccess = false;
                if (string.IsNullOrWhiteSpace(user_uid) && string.IsNullOrWhiteSpace(house_code))
                {
                    ar.Add("未添加人脸一体机！");
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(user_uid))
                    {
                        ar.Add($"用户【{ user_uid }】所在楼栋未关联人脸一体机！");
                    }
                    else if (!string.IsNullOrWhiteSpace(house_code))
                    {
                        ar.Add($"房屋【{ house_code }】所在楼栋未关联人脸一体机！");
                    }
                    else
                    {
                        ar.Add("未添加人脸一体机！");
                    }
                }
            }
            else
            {
                ConcurrentDictionary<int, bool> dic = new ConcurrentDictionary<int, bool>();
                Parallel.ForEach(lstMao, new ParallelOptions { MaxDegreeOfParallelism = Config_.GetInt("MaxDegreeOfParallelism") ?? 2 }, mao =>
                {
                    string ip = mao.GetIP();
                    int port = mao.GetPort();
                    bool isOk = NetWork_.VisualTelnet(ip, port);
                    if (!isOk)
                    {
                        ar.Add($"人脸一体机【{ mao.mao_no }】ip【{ ip }】端口【{ port }】网络不通畅！");
                        ar.Obj.BadMaos.Add(mao);
                    }
                    else
                    {
                        ar.Obj.GoodMaos.Add(mao);
                    }
                    dic.TryAdd(mao.id, isOk);
                });
                if (lstMao.Count == dic.Count(it => it.Value == false))
                {
                    ar.IsSuccess = false;
                }
                else
                {
                    if (dic.Any(it => it.Value == false))
                    {
                        if (isForce)
                        {
                            ar.IsSuccess = false;
                        }
                        else
                        {
                            ar.Add("存在如上问题，是否还继续？");
                            DialogResult dr = MessageBox.Show(ar.ToAlertString(), "", MessageBoxButtons.YesNo);
                            if (dr == DialogResult.Yes)
                            {
                                ar.IsSuccess = true;
                                return ar;
                            }
                            else
                            {
                                ar.IsSuccess = false;
                            }
                        }
                    }
                    else
                    {
                        ar.IsSuccess = true;
                    }
                }
            }
            if (!ar.IsSuccess)
            {
                ar.Add("存在如上问题，操作失效！");
                MessageBox.Show(ar.ToAlertString());
            }
            return ar;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="house_code">若user_id有值，则优先user_id</param>
        /// <returns></returns>
        public List<Mao> GetSectionMao(string user_id, string house_code)
        {
            if (string.IsNullOrWhiteSpace(user_id) && string.IsNullOrWhiteSpace(house_code))
            {
                return _maoBLL.Get();
            }
            else
            {
                if (Config_.GetBool("IsFaceSection") ?? false)
                {
                    if (!string.IsNullOrWhiteSpace(user_id))
                    {
                        return _maoBLL.GetForFaceSection(user_id);
                    }
                    else if (!string.IsNullOrWhiteSpace(house_code))
                    {
                        return _maoBLL.GetForFaceSection(user_id);
                    }
                    else
                    {
                        return _maoBLL.Get();
                    }
                }
                else
                {
                    return _maoBLL.Get();
                }
            }
        }
        /// <summary>
        /// 基本的检查
        /// </summary>
        /// <returns></returns>
        public void BasicCheckRender(ActionResult actionResult)
        {
            this.Close();
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="maoCheckResult">人脸一体机检查结果</param>
        /// <param name="user"></param>
        /// <param name="lstPicUrlAndFaceIDVO"></param>
        /// <param name="endTime"></param>
        /// <param name="registerCompleted"></param>
        public void Register(MaoCheckResult maoCheckResult, User user, List<PicUrlAndFaceIDVO> lstPicUrlAndFaceIDVO, DateTime? endTime, Action<List<string>> registerCompleted)
        {
            if (!endTime.HasValue)
            {
                //若未指定激活时间，则按照设置设定
                int defaultDays = Config_.GetInt("FaceEndTime") ?? 365;
                endTime = DateTime.Now.AddDays(defaultDays + 1).AddSeconds(-1);
            }

            Task.Run(() =>
            {
                var goodMaos = maoCheckResult.GoodMaos;
                if (!goodMaos.Any())
                {
                    ShowMessage($"关联的人脸一体机皆通讯异常！注册失败", MessageType.Information);
                    return;
                }
                List<string> lstPhotoUrlForRemove = new List<string>();
                Register(maoCheckResult, user, lstPicUrlAndFaceIDVO, endTime, lstPhotoUrlForRemove);

                registerCompleted(lstPhotoUrlForRemove);

            }).ContinueWith((obj) =>
            {
                BtnClose.Enabled = true;
            });
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="maoCheckResult"></param>
        /// <param name="user"></param>
        /// <param name="lstPicUrlAndFaceIDVO"></param>
        /// <param name="endTime"></param>
        /// <param name="lstPhotoUrlForRemove"></param>
        private void Register(MaoCheckResult maoCheckResult, User user, List<PicUrlAndFaceIDVO> lstPicUrlAndFaceIDVO, DateTime? endTime, List<string> lstPhotoUrlForRemove)
        {
            var goodMaos = maoCheckResult.GoodMaos;
            //找到第一个有效的人脸注册信息！
            var register = _registerBLL.FirstOrDefault(it => it.is_del != IsDelType.是 && it.user_uid == user.user_uid);
            foreach (PicUrlAndFaceIDVO item in lstPicUrlAndFaceIDVO)
            {
                //随机抽选一个台人脸一体机
                Mao mao = goodMaos[new Random().Next(goodMaos.Count - 1)];
                string ip = mao.GetIP();
                int port = mao.GetPort();
                Face.Common_.Face face = FaceFactory.CreateFace(mao.GetIP(), mao.GetPort(), FaceVender.EyeCool);

                ShowMessage($"开始注册用户【{ user.name }】的人脸信息【{ item.image_path }】", MessageType.Information);

                string faceId = item.face_id;

                ActionResult checkResult = face.Checking(faceId, RegisterType.手动注册, Image_.ImageToBase64(item.image_path), "客户端检查");
                if (!checkResult.IsSuccess)
                {
                    ShowMessage(checkResult.ToAlertString(), MessageType.Warning);
                    //不包含人脸特征，进行下一张验证
                    continue;
                }
                else
                {
                    item.face_id = faceId;
                    item.mao_id = mao.id;
                }

                //若有存在有效的人脸注册信息，则需要进行比较，确定是否同一个人
                if (register != null && !string.IsNullOrWhiteSpace(register.face_id))
                {
                    ActionResult<bool> mcResult = face.MatchCompare(item.face_id, register.face_id);
                    if (!mcResult.IsSuccess)
                    {
                        ShowMessage(mcResult.ToAlertString(), MessageType.Warning);
                        continue;
                    }
                    else if (!mcResult.Obj)
                    {
                        ShowMessage(mcResult.ToAlertString(), MessageType.Warning);
                        //非同一个人，进行下一张验证
                        continue;
                    }
                }
                //====================已通过基本验证========================
                string savedPictureName = _registerBLL.FileSaveAs(item.image_path, FacePlatformCache.GetPictureDirectory());//保存图片到本地
                if (string.IsNullOrEmpty(savedPictureName))
                {
                    ShowMessage("图片保存失败，请稍后重试！", MessageType.Error);
                    continue;
                }

                Register newRegister = new Register
                {
                    user_uid = user.user_uid,
                    face_id = faceId,
                    photo_path = savedPictureName,
                    register_type = RegisterType.手动注册,
                    check_state = CheckType.审核不通过,
                };
                var registerResult = _registerBLL.Add(newRegister);
                if (!registerResult.IsSuccess)
                {
                    ShowMessage("数据库异常，请稍后重试!", MessageType.Error);
                    continue;
                }

                lstPhotoUrlForRemove.Add(item.image_path);//图片添加到删除列表
                List<bool> lstIsAudited = new List<bool>();

                Parallel.ForEach(goodMaos, new ParallelOptions { MaxDegreeOfParallelism = Config_.GetInt("MaxDegreeOfParallelism") ?? 2 }, itemMao =>
                {
                    Face.Common_.Face faceItem = FaceFactory.CreateFace(itemMao.GetIP(), itemMao.GetPort(), FaceVender.EyeCool);

                    if (itemMao.id != mao.id)//已添加过图片，无需再添加
                    {
                        ActionResult result = faceItem.Checking(faceId, RegisterType.手动注册, Image_.ImageToBase64(item.image_path), "客户端检查");
                        if (!result.IsSuccess)
                        {
                            ShowMessage(result.ToAlertString(), MessageType.Warning);
                            return;
                        }
                    }
                    var registerResultItem = faceItem.Register(new RegisterInput()
                    {
                        ActiveTime = endTime.Value,
                        Birthday = user.birthday,
                        CertificateType = Face.Common_.EyeCool.CertificateType.唯一标识,
                        MaoNO = itemMao.mao_no,
                        UserUid = user.user_uid,
                        FaceId = faceId,
                        Name = user.name,
                        PeopleId = user.people_id,
                        Phone = user.mobile,
                        ProjectCode = Program._Mainform._ProjectCode,
                        RegisterType = RegisterType.手动注册,
                        RoomNo = "",//这个信息不重要暂时不填写
                        Sex = user.sex,
                        UserType = _userBLL.GetUserType(user.user_uid)
                    });

                    if (registerResultItem.IsSuccess)
                    {
                        ShowMessage($"人脸一体机【{ itemMao.mao_name }】上注册用户【{user.name}】的人脸信息成功！", MessageType.Success);
                        lstIsAudited.Add(registerResultItem.Obj.IsAudited);
                        if (register == null)
                        {
                            //用于下一次的循环！
                            register = _registerBLL.FirstOrDefault(it => it.is_del != IsDelType.是 && it.user_uid == user.user_uid);
                        }
                    }
                    else
                    {
                        ShowMessage($"人脸一体机【{ itemMao.mao_name }】上注册用户【{user.name}】的人脸信息失败(稍后将自动重试)：" + registerResultItem.ToAlertString(), MessageType.Error);

                        MaoFailedJob job = new MaoFailedJob
                        {
                            register_or_user_id = newRegister.id,
                            mao_id = itemMao.id,
                            job_type = JobType.注册,
                        };
                        _maoFailedJobBLL.AddOrUpdate(it => new
                        {
                            it.register_or_user_id,
                            it.mao_id,
                            it.job_type
                        }, job);
                    }
                });

                if (maoCheckResult.BadMaos.Any())
                {
                    foreach (var badMao in maoCheckResult.BadMaos)
                    {
                        ShowMessage($"人脸一体机【{ badMao.mao_name }】网络不通畅，注册用户【{user.name}】的人脸信息失败(稍后将自动重试)", MessageType.Error);
                    }
                    _maoFailedJobBLL.AddOrUpdate(it => new
                    {
                        it.register_or_user_id,
                        it.mao_id,
                        it.job_type
                    }, maoCheckResult.BadMaos.Select(it => new MaoFailedJob
                    {
                        register_or_user_id = newRegister.id,
                        mao_id = it.id,
                        job_type = JobType.注册,
                    }).ToArray());
                }

                if (lstIsAudited.Any(it => it == false))
                {
                    if (user.check_state != CheckType.审核通过)
                    {
                        user.check_state = CheckType.待审核;
                    }
                }

                if (lstIsAudited.Any(it => it == true))
                {
                    newRegister.check_state = CheckType.审核通过;
                    newRegister.change_time = DateTime.Now;
                    _registerBLL.Edit(newRegister);
                    user.check_state = CheckType.审核通过;
                    user.check_by = Program._Account.id;
                    user.check_time = DateTime.Now;
                }

                user.change_time = DateTime.Now;
                user.reg_time = user.check_time = DateTime.Now;
                user.end_time = endTime.Value;
                _userBLL.Edit(user);
            }
        }

        /// <summary>
        /// 批量注册人脸
        /// </summary>
        /// <param name="maoCheckResult"></param>
        /// <param name="files"></param>
        public void RegisterPictures(MaoCheckResult maoCheckResult, FileInfo[] files)
        {
            Task.Run(() =>
            {
                try
                {
                    var goodMaos = maoCheckResult.GoodMaos;
                    if (!goodMaos.Any())
                    {
                        ShowMessage($"关联的人脸一体机皆通讯异常！注册失败", MessageType.Information);
                        return;
                    }
                    RegisterPicturesHandle(maoCheckResult, files);
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                }
            }).ContinueWith((obj) =>
            {
                BtnClose.Enabled = true;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="faces"></param>
        /// <param name="files"></param>
        void RegisterPicturesHandle(MaoCheckResult maoCheckResult, FileInfo[] files)
        {
            int defaultDays = Config_.GetInt("FaceEndTime") ?? 365;
            DateTime endDate = Convert.ToDateTime(DateTime.Now.AddDays(defaultDays).ToString("yyyy-MM-dd 23:59:59"));

            Dictionary<string, List<PicUrlAndFaceIDVO>> dic = new Dictionary<string, List<PicUrlAndFaceIDVO>>();
            ShowMessage($"开始检查图片：", MessageType.Warning);
            foreach (var item in files)
            {
                string fileExtension = Path.GetExtension(item.FullName);
                string fileName = Path.GetFileNameWithoutExtension(item.FullName);
                if (fileExtension.ToLower() != ".jpg")
                {
                    ShowMessage($"图片【{fileName}】后缀非jpg图片，仅支持jpg格式图片！", MessageType.Warning);
                    continue; ;
                }
                string[] split = fileName.Split('_');
                if (split.Length > 0)
                {
                    string name = split[0];
                    string index = "1";
                    if (split.Length > 1) index = split[1];

                    if (!dic.ContainsKey(name))
                    {
                        dic.Add(name, new List<PicUrlAndFaceIDVO>());
                    }

                    var lst = dic[name] ?? new List<PicUrlAndFaceIDVO>();
                    lst.Add(new PicUrlAndFaceIDVO()
                    {
                        face_id = Key_.SequentialGuid(),
                        image_path = item.FullName,
                        mao_id = 0 //0，表示都未做过检查
                    });
                }
            }

            foreach (var name in dic.Keys)
            {
                var getWorkerResult = _userBLL.GetWorkerByName(name);
                if (getWorkerResult.IsSuccess)
                {
                    var lstPicUrlAndFaceIDVO = dic[name];
                    var worker = getWorkerResult.Obj;
                    List<string> lstPhotoUrlForRemove = new List<string>();
                    Register(maoCheckResult, worker, lstPicUrlAndFaceIDVO, endDate, lstPhotoUrlForRemove);
                }
                else
                {
                    ShowMessage(getWorkerResult.ToAlertString(), MessageType.Error);
                }
            }
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="maoCheckResult"></param>
        /// <param name="lstRegisterWithUser"></param>
        /// <param name="checkType"></param>
        /// <param name="check_note"></param>
        /// <param name="reviewCompleted"></param>
        public void Review(List<Register> lstRegisterWithUser, CheckType checkType, string check_note, Action<ActionResult> reviewCompleted)
        {
            Task.Run(() =>
            {
                string project_code = Program._Mainform._ProjectCode;

                var lstALLMao = _maoBLL.Get();
                foreach (Register registerWithUser in lstRegisterWithUser)
                {
                    List<Mao> lstMao = null;
                    bool isFaceSection = Config_.GetBool("IsFaceSection") ?? false;
                    if (isFaceSection)
                    {
                        lstMao = _maoBLL.GetForFaceSection(registerWithUser.user.user_uid);
                    }
                    else
                    {
                        lstMao = lstALLMao;
                    }

                    ShowMessage($"开始审核用户【{registerWithUser.user.name}】的人脸注册信息", MessageType.Information);

                    int check_by = Program._Account.id;
                    DateTime change_time = DateTime.Now;
                    List<ActionResult> lstActionResult = new List<ActionResult>();
                    List<MaoFailedJob> lstMaoFailedJob = new List<MaoFailedJob>();
                    Parallel.ForEach(lstMao,
                        new ParallelOptions { MaxDegreeOfParallelism = Config_.GetInt("MaxDegreeOfParallelism") ?? 2 },
                        (mao) =>
                        {
                            Face.Common_.Face face = FaceFactory.CreateFace(mao.GetIP(), mao.GetPort(), FaceVender.EyeCool);
                            if (face.VisualTelnet(mao.GetIP(), mao.GetPort()))
                            {
                                var result = face.Review(project_code, registerWithUser.user.people_id, registerWithUser.face_id, checkType, "客户端审核");
                                lstActionResult.Add(result);
                                if (result.IsSuccess)
                                {
                                    ShowMessage($"人脸一体机【{ mao.mao_name }】对【{registerWithUser.user.name}】的审核结果：【{ checkType }】", MessageType.Success);
                                }
                                else
                                {
                                    ShowMessage($"人脸一体机【{ mao.mao_name }】对【{registerWithUser.user.name}】的审核失败：【{ result.ToAlertString() }】", MessageType.Error);

                                    lstMaoFailedJob.Add(new MaoFailedJob
                                    {
                                        register_or_user_id = registerWithUser.id,
                                        mao_id = mao.id,
                                        job_type = JobType.审核,
                                        failed_message = result.ToAlertString()
                                    });
                                }
                            }
                            else
                            {
                                ShowMessage($"人脸一体机【{ mao.mao_name }】对【{registerWithUser.user.name}】的审核失败（稍后自动重试）：【网络不通畅】", MessageType.Error);

                                lstMaoFailedJob.Add(new MaoFailedJob
                                {
                                    register_or_user_id = registerWithUser.id,
                                    mao_id = mao.id,
                                    job_type = JobType.审核,
                                    failed_message = "网络不通畅"
                                });
                            }
                        });
                    if (lstActionResult.Any(it => it.IsSuccess)) //只要有一个审核成功
                    {
                        registerWithUser.check_state = checkType;
                        registerWithUser.change_time = change_time;
                        var editResult = _registerBLL.Edit(registerWithUser);
                        if (editResult.IsSuccess)
                        {
                            User user = _userBLL.FirstOrDefault(it => it.user_uid == registerWithUser.user_uid);
                            user.check_by = Program._Account.id;
                            if (!string.IsNullOrWhiteSpace(check_note))
                            {
                                user.check_note = check_note;
                            }
                            user.check_state = checkType;
                            user.check_time = DateTime.Now;
                            var editUserResult = _userBLL.Edit(user);
                            if (editUserResult.IsSuccess)
                            {
                                //万事大吉
                            }
                            else
                            {
                                ShowMessage($"用户【{registerWithUser.user.name}】审核信息变更失败：【{ editUserResult.ToAlertString() }】", MessageType.Error);
                            }

                            if (lstMaoFailedJob.Any())
                            {
                                _maoFailedJobBLL.AddOrUpdate(it => new
                                {
                                    it.register_or_user_id,
                                    it.mao_id,
                                    it.job_type
                                }, lstMaoFailedJob.ToArray());
                            }
                        }
                        else
                        {
                            ShowMessage($"用户【{registerWithUser.user.name}】的人脸信息变更失败：【{ editResult.ToAlertString() }】", MessageType.Error);
                        }
                        reviewCompleted(editResult);
                    }
                }
            }).ContinueWith((obj) =>
            {
                BtnClose.Enabled = true;
            });
        }
        /// <summary>
        /// 设置延迟时间
        /// </summary>
        /// <param name="isYear"></param>
        public void SetEndTime(List<RegisterManageDto> data, bool isYear)
        {
            Task.Run(() =>
            {
                try
                {
                    DateTime endTime = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
                    if (isYear)
                    {
                        endTime = endTime.AddYears(1);
                    }
                    else
                    {
                        endTime = endTime.AddMonths(1);
                    }

                    ActionResult result = new ActionResult();

                    var lstALLMao = _maoBLL.Get();
                    foreach (RegisterManageDto dto in data)
                    {
                        List<Mao> lstMao = null;
                        bool isFaceSection = Config_.GetBool("IsFaceSection") ?? false;
                        if (isFaceSection)
                        {
                            lstMao = _maoBLL.GetForFaceSection(dto.user_uid);
                        }
                        else
                        {
                            lstMao = lstALLMao;
                        }
                        List<ActionResult> lstActionResult = new List<ActionResult>();
                        List<MaoFailedJob> lstMaoFailedJob = new List<MaoFailedJob>();
                        Parallel.ForEach(lstMao,
                            new ParallelOptions { MaxDegreeOfParallelism = Config_.GetInt("MaxDegreeOfParallelism") ?? 2 },
                            (mao) =>
                            {
                                Face.Common_.Face face = FaceFactory.CreateFace(mao.GetIP(), mao.GetPort(), FaceVender.EyeCool);
                                if (face.VisualTelnet(mao.GetIP(), mao.GetPort()))
                                {
                                    var updateResult = face.UpdateActiveTime(dto.user_uid, endTime);
                                    if (updateResult.IsSuccess)
                                    {
                                        ShowMessage($"人脸一体机【{ mao.mao_name }】对【{dto.user_name}】的延期成功", MessageType.Error);
                                    }
                                    else
                                    {
                                        ShowMessage($"人脸一体机【{ mao.mao_name }】对【{dto.user_name}】的延期设置失败（稍后自动重试）：【{updateResult.ToAlertString()}】", MessageType.Error);
                                    }
                                    lstActionResult.Add(updateResult);
                                }
                                else
                                {
                                    ShowMessage($"人脸一体机【{ mao.mao_name }】对【{dto.user_name}】的延期设置失败（稍后自动重试）：【网络不通畅】", MessageType.Error);

                                    lstMaoFailedJob.Add(new MaoFailedJob
                                    {
                                        register_or_user_id = dto.id,
                                        mao_id = mao.id,
                                        job_type = JobType.审核,
                                        failed_message = "网络不通畅"
                                    });
                                }
                            });

                        if (lstActionResult.Any(it => it.IsSuccess)) //只要有一个延期成功
                        {
                            _userBLL.Edit(it => it.user_uid == dto.user_uid, it => new User
                            {
                                change_time = DateTime.Now,
                                end_time = endTime
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                }
                finally
                {
                    _actionResult.Obj = false;
                }
            }).ContinueWith((obj) =>
            {
                BtnClose.Enabled = true;
            });
        }
        /// <summary>
        /// 房屋删除用户
        /// </summary>
        /// <param name="maoCheckResult"></param>
        /// <param name="userHouseWithUserAndHouse"></param>
        public void DeleteUserHouse(MaoCheckResult maoCheckResult, UserHouse userHouseWithUserAndHouse)
        {
            ClearMessage();

            Task.Run(() =>
            {
                try
                {
                    User user = userHouseWithUserAndHouse.User;
                    if (user.data_from == DataFromType.CRM)
                    {
                        ShowMessage($"不能删除CRM用户【{ user.name }】！", MessageType.Warning);
                        return;
                    }

                    var goodMaos = maoCheckResult.GoodMaos;
                    if (!goodMaos.Any())
                    {
                        ShowMessage($"关联的人脸一体机皆通讯异常！删除失败", MessageType.Information);
                        return;
                    }
                    if (maoCheckResult.BadMaos.Any())
                    {
                        ShowMessage($"需要所有关联的人脸一体机通讯正常，才允许删除！", MessageType.Information);
                        return;
                    }

                    var registers = _registerBLL.Get(it => it.user_uid == userHouseWithUserAndHouse.user_uid && it.is_del != IsDelType.是);

                    if (registers.Any())
                    {
                        List<ActionResult> lstDelResult = new List<ActionResult>();
                        List<MaoFailedJob> lstMaoFailedJob = new List<MaoFailedJob>();
                        Parallel.ForEach(goodMaos, new ParallelOptions { MaxDegreeOfParallelism = Config_.GetInt("MaxDegreeOfParallelism") ?? 2 }, (mao) =>
                        {
                            Face.Common_.Face face = FaceFactory.CreateFace(mao.GetIP(), mao.GetPort(), FaceVender.EyeCool);
                            foreach (var register in registers)
                            {
                                var delResult = face.FaceDel(userHouseWithUserAndHouse.User.people_id, register.face_id);
                                lstDelResult.Add(delResult);
                                if (delResult.IsSuccess)
                                {
                                    ShowMessage($"从人脸一体机【{ mao.mao_name }】上删除用户【{ user.name }】的人脸注册信息【register.id{ register.id }】成功！", MessageType.Success);
                                }
                                else
                                {
                                    ShowMessage($"从人脸一体机【{ mao.mao_name }】上删除用户【{ user.name }】的人脸注册信息【register.id{ register.id }】失败(稍后将自动重试)：{ delResult.ToAlertString() }！", MessageType.Error);

                                    lstMaoFailedJob.Add(new MaoFailedJob
                                    {
                                        register_or_user_id = register.id,
                                        mao_id = mao.id,
                                        job_type = JobType.注册,
                                        failed_message = delResult.ToAlertString()
                                    });
                                }
                            }
                        });

                        //只要有一个已删除
                        if (lstDelResult.Any(it => it.IsSuccess == true))
                        {
                            registers.ForEach((register) =>
                            {
                                register.change_time = DateTime.Now;
                                register.is_del = IsDelType.是;
                            });
                            var editResult = _registerBLL.Edit(registers);
                            if (editResult.IsSuccess)
                            {
                                if (lstMaoFailedJob.Any())
                                {
                                    _maoFailedJobBLL.AddOrUpdate(it => new
                                    {
                                        it.register_or_user_id,
                                        it.mao_id,
                                        it.job_type
                                    }, lstMaoFailedJob.ToArray());
                                }
                            }
                            else
                            {
                                ShowMessage($"删除用户【{ user.name }】的人脸信息失败：{ editResult.ToAlertString() }！", MessageType.Error);
                            }
                        }
                        else if (lstDelResult.Count(it => it.IsSuccess == false) == goodMaos.Count)
                        {
                            ShowMessage($"删除用户【{ user.name }】的人脸信息都失败，导致删除用户失败！", MessageType.Error);
                            return;
                        }
                    }
                    List<ActionResult> lstDelUserResult = new List<ActionResult>();
                    Parallel.ForEach(goodMaos, new ParallelOptions { MaxDegreeOfParallelism = Config_.GetInt("MaxDegreeOfParallelism") ?? 2 }, (mao) =>
                    {
                        Face.Common_.Face face = FaceFactory.CreateFace(mao.GetIP(), mao.GetPort(), FaceVender.EyeCool);
                        var delUserResult = face.UserDel(user.people_id);
                        lstDelUserResult.Add(delUserResult);
                        if (delUserResult.IsSuccess)
                        {
                            ShowMessage($"从人脸一体机【{ mao.mao_name }】上删除用户【{ user.name }】成功！", MessageType.Success);
                        }
                        else
                        {
                            ShowMessage($"从人脸一体机【{ mao.mao_name }】上删除用户【{ user.name }】失败(稍后将自动重试)：{ delUserResult.ToAlertString() }！", MessageType.Error);
                        }
                    });

                    if (lstDelUserResult.Any(it => it.IsSuccess))
                    {
                        userHouseWithUserAndHouse.is_del = IsDelType.是;
                        userHouseWithUserAndHouse.User.change_time = DateTime.Now;
                        userHouseWithUserAndHouse.User.is_del = IsDelType.是;
                        var editUserHouseResult = _userHouseBLL.Edit(userHouseWithUserAndHouse);
                        if (editUserHouseResult.IsSuccess)
                        {
                            this.DialogResult = DialogResult.OK;
                            ShowMessage($"删除用户【{ user.name }】成功！", MessageType.Success);
                        }
                        else
                        {
                            ShowMessage($"删除用户【{ user.name }】失败：{ editUserHouseResult.ToAlertString() }", MessageType.Error);
                        }
                    }
                    else
                    {
                        ShowMessage($"从人脸一体机上删除用户【{ user.name }】都失败，导致删除用户失败！", MessageType.Error);
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage(Exception_.GetInnerException(ex).Message, MessageType.Error);
                    LogHelper.Error(ex);
                }
                finally
                {
                }
            }).ContinueWith((obj) =>
            {
                BtnClose.Enabled = true;
            });
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="maoCheckResult"></param>
        /// <param name="user"></param>
        /// <param name="register"></param>
        /// <param name="deleteCompleted"></param>
        public void DeleteRegistedImage(MaoCheckResult maoCheckResult, User user, Register register, Action deleteCompleted)
        {
            ClearMessage();

            Task.Run(() =>
            {
                try
                {
                    var goodMaos = maoCheckResult.GoodMaos;
                    if (!goodMaos.Any())
                    {
                        ShowMessage($"关联的人脸一体机皆通讯异常！删除失败", MessageType.Information);
                        return;
                    }
                    if (maoCheckResult.BadMaos.Any())
                    {
                        ShowMessage($"需要所有关联的人脸一体机通讯正常，才允许删除！", MessageType.Information);
                        return;
                    }

                    List<bool> lstDel = new List<bool>();
                    Parallel.ForEach(goodMaos, new ParallelOptions { MaxDegreeOfParallelism = Config_.GetInt("MaxDegreeOfParallelism") ?? 2 }, (mao) =>
                    {
                        Face.Common_.Face face = FaceFactory.CreateFace(mao.GetIP(), mao.GetPort(), FaceVender.EyeCool);

                        var delResult = face.FaceDel(user.people_id, register.face_id);
                        if (delResult.IsSuccess)
                        {
                            lstDel.Add(true);
                            ShowMessage($"从人脸一体机【{ mao.mao_name }】上删除成功！", MessageType.Success);
                        }
                        else
                        {
                            lstDel.Add(false);
                            ShowMessage($"从人脸一体机【{ mao.mao_name }】上删除失败(稍后将自动重试)：{ delResult.ToAlertString() }！", MessageType.Error);

                            _maoFailedJobBLL.AddOrUpdate(it => new
                            {
                                it.register_or_user_id,
                                it.mao_id,
                                it.job_type
                            }, new MaoFailedJob
                            {
                                register_or_user_id = register.id,
                                mao_id = mao.id,
                                job_type = JobType.注册,
                            });
                        }
                    });

                    if (lstDel.Any(it => it == true))
                    {
                        register.is_del = IsDelType.是;
                        var editResult = _registerBLL.Edit(register);
                        if (editResult.IsSuccess)
                        {
                            string filePath = Path.Combine(FacePlatformCache.GetPictureDirectory(), register.photo_path);
                            if (File.Exists(filePath))
                            {
                                try
                                {
                                    File.Delete(filePath);
                                }
                                catch { }
                            }
                        }
                    }

                    //若都删掉了
                    bool userRegisted = _registerBLL.Any(it => it.user_uid == user.user_uid && it.is_del != IsDelType.是);
                    if (!userRegisted)
                    {
                        user.change_time = DateTime.Now;
                        user.check_state = CheckType.审核不通过;
                        _userBLL.Edit(user);
                    }

                    deleteCompleted();
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                }
                finally
                {
                    _actionResult.Obj = false;
                }
            }).ContinueWith((obj) =>
            {
                BtnClose.Enabled = true;
            });
        }
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        private void ShowMessage(string message, MessageType type)
        {
            tbMessage.UIThread(() =>
            {
                tbMessage.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "：" + message + Environment.NewLine + tbMessage.Text;
            }, true);
        }
        /// <summary>
        /// 清空
        /// </summary>
        private void ClearMessage()
        {
            tbMessage.UIThread(() =>
            {
                tbMessage.Text = string.Empty;
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FaceJobFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_actionResult.Obj)
            {
                this.UIThread(() =>
                {
                    HMMessageBox.Show(this, "任务还在进行中，不允许中途退出！");
                });
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (_actionResult.IsSuccess)
            {

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
