<div dir="rtl">

<div style = "font-size:28px; font-weight:bold; margin-bottom:10px;">SanaAPI</div>
<p style = "direction:rtl; text-align:right;" dir="rtl">

> هدف از انجام این پروژه تهیه نرخ ارزها از API سایت SanaRate و ذخیره آن ها در دیتابیس می باشد.
در حقیقت  شما یک برنامه کنسول .NET Core console ایجاد می کنید که دسترسی به داده ها را در  پایگاه داده SQLite با استفاده از  Entity Framework Core  فراهم می کند.
</p>
<hr>

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:rtl; text-align:right;" dir="rtl">تکنولوژی ها</div>

<div dir="ltr">

    * .NET CORE 5

    * Microsoft.EntityFrameworkCore.Sqlite

    * Microsoft.EntityFrameworkCore.Tools

    * Newtonsoft.Json

</div>

---

<div style = "font-size:20px; font-weight:bold;"> فهرست مطالب </div>

[[_TOC_]]

---

# نیازمندی های پروژه
* 1-  Frame Work های زیر را به پروژه اضافه نمایید:

<div dir="ltr">

    * Microsoft.EntityFrameworkCore.Sqlite

    * Microsoft.EntityFrameworkCore.Tools

    * Newtonsoft.Json

</div>

* 2-  NameSpace های زیر را در File Class اضافه نمایید.

<div dir="ltr">

    * using Microsoft.EntityFrameworkCore;

    * using Newtonsoft.Json;

    * using System.Net.Http;

</div>

---

<div dir="rtl">

# نحوه نصب Entity FrameWork در پروژه

* جهت نصب EF در پروژه می توانید به روش های زیر عمل نمایید:

1- Tools > NuGet Package Manager > Package Manager Console

2- Command زیر را در PowerShell بنویسید:

<div style = "direction:ltr; text-align:left;" dir="ltr">

    * Install-Package Microsoft.EntityFrameworkCore.Sqlite

</div>

3- همچنین می توانید روی پروژه کلیک راست کرده و گزینه Manage NuGet Packages را انتخاب نمایید.

</div>

---

# نحوه ایجاد DataBase
* مراحل زیر را طی کنید و با استفاده از Migration ها DataBase را ایجاد نمایید. Command های زیر را در  Package Manager Console (PMC) اجرا نمایید:

<div dir="ltr">

    1- Install-Package Microsoft.EntityFrameworkCore.Tools

    2- Add-Migration InitialCreate

    3- Update-Database

* The Add-Migration command scaffolds a migration to create the initial set of tables for the model. The Update-Database command creates the database and applies the new migration to it.
</div>

---

# Run the app
<div dir="ltr">

* Visual Studio uses an inconsistent working directory when running .NET Core console apps. (see dotnet/project-system#3619) This results in an exception being thrown: no such table: Blogs. To update the working directory:

    * Right-click on the project and select Edit Project File

    * Just below the TargetFramework property, add the following:
        `<StartWorkingDirectory>$(MSBuildProjectDirectory)</StartWorkingDirectory>`
    
    *  Save the file

Now you can run the app:

    * Debug > Start Without Debugging

</div>

* جزئیات بیشتر در خصوص ساختار پروژه و مراحل آن در Wiki ارائه گردیده است:

    * [Project Structure](https://alm.index-holding.com/IndexCollection/SoftDept/_wiki/wikis/SoftDept.wiki/42/Project-Structure)
    
</div>