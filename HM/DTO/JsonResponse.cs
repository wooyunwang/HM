using HM.Utils_;

namespace HM.DTO
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonResponse<T>
    {
        public JsonResponse(ActionResult ar)
        {
            status = ar.IsSuccess ? 1 : 0;
            message = ar.ToAlertString();
        }
        public JsonResponse(ActionResult<T> ar)
        {
            status = ar.IsSuccess ? 1 : 0;
            message = ar.ToAlertString();
            data = ar.Obj;
        }

        public JsonResponse(T data)
        {
            status = 1;
            this.data = data;
        }
        public JsonResponse()
        {
            status = 1;
        }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Json_.GetString(this);
        }
    }
}
