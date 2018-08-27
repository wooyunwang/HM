# 说明

### 插件支持
* 下载安装mysql-connector-net-6.8.8.msi，Complete安装
* 下载安装mysql-for-visualstudio-1.2.8.msi，Complete安装

### 安装Nuget包
``` xml
<packages>
  <package id="EntityFramework" version="6.2.0" targetFramework="net451" />
  <package id="MySql.Data" version="6.8.8" targetFramework="net451" />
  <package id="MySql.Data.Entity" version="6.8.8" targetFramework="net451" />
</packages>
```

### 使用DBFirst

##### 生成edmx的问题
> 无法生成模型:“System.Data.StrongTypingException: 表“TableDetails”中列“IsPrimaryKey”的值为 DBNull

解决办法：
1. 运行services.msc，重启MySQL服务.
2. 在MySQL运行一下命令：   
``` sql
use face_platform_18_09;   
set @@optimizer_switch='derived_merge=OFF';

use wechatface;   
set @@optimizer_switch='derived_merge=OFF';
```
3. 重新生成 .edmx