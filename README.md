# RFID-Bigproject
rfid全部所学

RFID课程期末的大作业
从大作业报告里粘贴过来，懒得写了
数据库为相对路径

本项目的任务提出者是RFID教师，开发者是上RFID课的学生,用户是潜在用户

本产品是针对电脑管理图书的需求设计的，借用嵌入式RFI，可以完成读者来访记录、读者借还书、图书登记、图书查询，删除，书库查看功能。
参考资料
来自csdn，github，博客园下附链接。
https://download.csdn.net/download/qq_37056790/9888121
https://download.csdn.net/download/zjg076000/10444942
https://download.csdn.net/download/liliuling/2890193
https://download.csdn.net/download/a87462272/2131196
https://download.csdn.net/download/linlizhq/3380358
https://download.csdn.net/download/liuchang0117/2024661
https://github.com/ygsama/BooK-Library-System
https://github.com/raojun/BookManage
https://github.com/kgdpevj/LibraryManagementProfessional
https://www.cnblogs.com/go2bed/p/4166183.html
系统结构
我们用两层体系结构作为图书馆管理信息系统软件解决方案的核心，将系统的操作人员划分为三类：读者，工作人员，系统管理员
依据软件工程的基本原理，详细设计阶段的根本任务是确定应该怎样具体实现所要求的系统，也就是说，经过这个阶段的设计工作，应该得出对目标系统的精确描述，从而在系统实现阶段可以把这个描述直接翻译成用某种程序设计语言书写的程序。具体来说就是把经过总体设计得到的各个模块详细的加以描述。
 

程序设计说明

程序描述
假设每个学生都携带一张125K卡，每次进入图书馆进行一次登记记录。
图书馆里的图书用15693卡做标记，每本书对应一张15693卡，书籍信息存储在数据库，所存储书籍信息如下所示（Borrow用于记录图书状态，表示该书是否存于图书馆，是否可以借出）：

功能包括：添加书籍信息
		借阅/归还
		查询书库
		来访记录
		删除图书
		支持查阅图书馆是否存在该书籍，可以由书号查询，也可以由书名查询。



储存分配
内部数据：
数据库存储了书籍的八个信息：
BookNo：书号
BookName：书名
Author：作者
Publisher：出版社
Format：版式
Page：页数
Price：价格
EnterDate：存入日期
Borrow：存储状态
 


限制条件
技术约束 
    本项目的设计是在汉语程序设计语言（C#）的条件下进行的，技术设计采用软硬一体化的设计方法。 
	
环境约束 
运行该软件所适用的具体环境windows使用2012版Visual Studio，基于.NET Framework 4.5框架，采用vs自带的数据库，尚不清楚版本号。
有待改进的地方：
实现功能比较简单，有待优化
125K刷卡数据传输受技术限制，没有实现
显示整个表数据时时间无法显示，是格式还是其他问题，尚不清楚
用书名查询书籍时显示的所有数据为0，尚未解决
