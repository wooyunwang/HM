# 黑猫一号集软件开发说明文档-制作编辑流程

## 1. 工具支持

* 安装NodeJs，参考地址：https://www.w3cschool.cn/nodejs/
* 安装Visual Studio Code，下载地址：https://code.visualstudio.com/

## 2、MarkDown语法学习

* 官方文档： http://gitbook.site/syntax/markdown.html
* 其他文档：https://www.w3cschool.cn/markdownyfsm/markdownyfsm-odm6256r.html

## 3、GitBook使用说明

* 官方文档：http://gitbook.site/

* 其他文档：http://gitbook.zhangjikai.com/

## 4. 编辑

* 创建开发文档目录：HM.GitBook.Dev
* 创建 SUMMARY.md MarkDown文件
* 编辑 SUMMARY.md ，添加目录
* 打开cmd，cd至HM.GitBook.Dev目录，执行指令GitBook Init
* 使用Visual Studio Code 打开HM.GitBook.Dev文件夹，打开对应的MarkDown文件进行编辑
* 添加Syles文件夹，添加Website.css，进行相关样式编辑
* 添加Book.json文件，进行相关配置

## 5. 预览

* 打开命令提示符cmd（管理员），cd至HM.GitBook.Dev。
* 若book.json配置了新的插件，请执行gitbook install指令，它将自动为您安装好插件。
* 输入指令 gitbook serve，它将编译输出在HM.GitBook.Dev文件目录的_book目录下。
* 打开浏览器浏览。
* 若需要导航等效果，可以在Visual Studio Code中，将$(SolutionDir)HM.GitBook.Dev\_book\Styles\WebSite.css中的屏蔽样式清除，再刷新浏览器http://localhost:4000

## 6. 发布

* 打开命令提示符cmd, cd至HM.GitBook.Dev
* 执行指令：mkdir D:\Publish\HM.GitBook.Dev 【创建目标目录HM.GitBook.Dev】
* 执行指令：cd..,退到上一层目录(如果不，会出错)
* 执行指令：gitbook build HM.GitBook.Dev D:\Publish\HM.GitBook.Dev

    ```
    C:\Users\caizz>d:

    D:\>cd D:\Users\caizz\Documents\Visual Studio 2017\Projects\HM\HM.GitBook.Dev

    D:\Users\caizz\Documents\Visual Studio 2017\Projects\HM\HM.GitBook.Dev>mkdir D:\Publish\HM.GitBook.Dev

    D:\Users\caizz\Documents\Visual Studio 2017\Projects\HM\HM.GitBook.Dev>gitbook build HM.GitBook.Dev D:\Publish\HM.GitBook.Dev
    Error: ENOENT: no such file or directory, scandir 'D:\Users\caizz\Documents\Visual Studio 2017\Projects\HM\HM.GitBook.Dev\HM.GitBook.Dev'

    D:\Users\caizz\Documents\Visual Studio 2017\Projects\HM\HM.GitBook.Dev>cd ..
    
    D:\Users\caizz\Documents\Visual Studio 2017\Projects\HM>gitbook build HM.GitBook.Dev D:\Publish\HM.GitBook.Dev
    info: 7 plugins are installed
    info: 6 explicitly listed
    info: loading plugin "highlight"... OK
    info: loading plugin "search"... OK
    info: loading plugin "lunr"... OK
    info: loading plugin "sharing"... OK
    info: loading plugin "fontsettings"... OK
    info: loading plugin "theme-default"... OK
    info: found 13 pages
    info: found 13 asset files
    info: >> generation finished with success in 1.5s !
    ```

### 导出Pdf

windows下gitbook转pdf

需要用到的工具:[calibre](https://www.fosshub.com/Calibre.html/calibre-2.77.0.msi),[phantomjs](http://phantomjs.org/download.html)

1将上述2个安装,calibre默认安装的路径C:\Program Files\Calibre2,phantomjs为你解压路径;

2并将其目录均加入到系统变量path中,参考:目录添加到系统变量path中;

3在cmd打开你需要转pdf的文件夹,输入gitbook pdf即可;



