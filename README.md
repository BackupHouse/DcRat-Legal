# DcRat

C#编写的支持多人协作的远控软件

## 编译

##### 编译环境

推荐使用：Windows 10 + vs2019(可直接使用)/vs2022(需要单独安装.NET Framework 4.0的目标包)

|项目|框架依赖|
|  ----  | ----  |
|DcRat|.NET Framework 4.7.2|
|Server|.NET 5.0|
|Client40|.NET Framework 4.0|
|Client35|.NET Framework 3.5|


##### 支持系统
|项目|支持系统(已测试)|
|  ----  | ----  |
|DcRat|Windows 7/8/8.1/10/11 && Windows Server 2008/2012/2016/2019/2022|
|Server|Windows Server 2019/Ubuntu 20.04|
|Client40|Windows 7/8/8.1/10/11|
|Client35|Windows 7/8/8.1/10/11|

##### 注意

- 本软件已添加GitHub Action自动构建，每次提交后会自动生成Tag为AutoBuild的[Release](https://github.com/Paragravity/DcRat/releases/tag/AutoBuild)，可以直接使用

## 使用

本程序采用Controler-TeamServer-Client三端通讯，您需要提前准备好一台具有公网IP的服务器，一个鉴权密码用于控制端与服务端鉴权

##### Server
- 此程序为服务端控制台程序，应部署于您的公网服务器上，运行时按照提示依次输入密码以及您想使用的端口即可

##### DcRat
- 此程序为控制端程序，运行时按照提示输入服务器地址及鉴权密码，其中服务器地址格式为**IP:Port**,之后按照界面文字图片指示使用即可
- 具体功能的使用指南将后续陆续完善

##### Client35/Client40
- 此程序为客户端程序，可以在DcRat中生成，可根据系统版本选择合适的客户端版本

## 免责声明

我（簞純）对您由使用或传播等由此软件引起的任何行为和/或损害不承担任何责任。您对使用此软件的任何行为承担全部责任，并承认此软件仅用于教育和研究目的。下载本软件或软件的源代码，您自动同意上述内容。 
