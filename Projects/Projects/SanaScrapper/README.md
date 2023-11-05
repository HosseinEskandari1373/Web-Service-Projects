<div dir="rtl">

<div style = "font-size:28px; font-weight:bold; margin-bottom:10px;">SanaScrapper</div>
<p style = "direction:rtl; text-align:right;" dir="rtl">

> هدف از انجام این پروژه تهیه نرخ ارزها از  سایت SanaRate و ذخیره آن ها در دیتابیس می باشد.
در حقیقت  شما یک برنامه کنسول .NET Core console ایجاد می کنید که دسترسی به داده ها را در  پایگاه داده SQLite با استفاده از  Entity Framework Core  فراهم می کند.

> به منظور واکشی اطلاعات از سایت می توانید از کتابخانه HtmlAgilityPack استفاده نمایید. در حقیقت کتابخانه HtmlAgilityPach یا Hap یک کتابخانه برای واکشی اطلاعات از یک صفحه وب می باشد. 

<div dir="ltr">

> In fact, htmlagiltypack, or Hap, is a library for fetching web page information comparable to AngleSharp. The whole thing is Html Parser, which means it reads a page and parses it and understands the content inside, and now we can do the operation with that content.

</div>

</p>
<hr>

<div style = "font-size:20px; font-weight:bold; margin-bottom:10px; direction:rtl; text-align:right;" dir="rtl">تکنولوژی ها</div>

<div dir="ltr">

    * .NET CORE 5

    * Microsoft.EntityFrameworkCore.Sqlite

    * Microsoft.EntityFrameworkCore.Tools

    * Fizzler.Systems.HtmlAgilityPack

    * HtmlAgilityPack

</div>

---

<div dir="ltr"> <p style = "font-size:20px; font-weight:bold;"> فهرست مطالب  </p>

[[_TOC_]]

</div>

---

# نیازمندی های پروژه
* 1-  FrameWork های زیر را به پروژه اضافه نمایید:

<div dir="ltr">

    * Microsoft.EntityFrameworkCore.Sqlite

    * Microsoft.EntityFrameworkCore.Tools

    * HtmlAgilityPack

    * Fizzler.Systems.HtmlAgilityPack

</div>

* 2-  NameSpace های زیر را در پروژه اضافه نمایید.

<div dir="ltr">

    * using Microsoft.EntityFrameworkCore;

    * using HtmlAgilityPack;

    * using Fizzler.Systems.HtmlAgilityPack;

    * using System.IO;

    * using System.Linq;

    * using System.Net;;

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

<div dir="ltr">

##Project Structure
<details><summary>View Project Structure</summary>
<p>

<div style="direction:ltr; text-align:left;" dir="ltr">

## Read Html Console Console Code
<details><summary>First, read the entire HTML document of the site with the following code so that you can extract the desired content from its heart:</summary>
<p>

 
            `//Get the document HTML
        public static HtmlDocument GetHtmlDoc()
        {
            var url = "https://fxmarketrate.cbi.ir/";

            var Client = new WebClient();
            var html = Client.DownloadString(url);

            var document = new HtmlDocument();

            //Load the Html Page in document
            document.LoadHtml(html);
            return document;
        }`

</p>
</details>

---   
## Example for fetching Data from SanaRate
<details><summary>First, select the content you want from the HTML document by Query, and remove the empty spaces, etc. with the commands related to the strings, and create the output as desired:</summary>
<p>

          ` //Fetch specific data from the weighted average banknote table
            public static void Weighted_Average_of_banknotes()
            {
            //Clean File txt
            File.WriteAllText(@"SanaRate_Scrapper.txt", "");

            var document = GetHtmlDoc();

            //Fetch table title
            var average_banknotes_title = document.DocumentNode.QuerySelectorAll("[id='MainContent_ViewCashChequeRates_tblNaghdHeader']");
            var innerText = average_banknotes_title.Select(node => node.InnerText);

            //Remove empty spaces from the fetched string and place it in the array
            string[] line = innerText.ToArray()[0].Split('\n');
            var cleanLine_average_banknotes = line.Where(line => !string.IsNullOrWhiteSpace(line)).Select(x => x.Trim()).ToArray();
            
            File.AppendAllLines(@"SanaRate_Scrapper.txt", cleanLine_average_banknotes);

            HtmlNodeCollection average_banknotes_table = document.DocumentNode.SelectNodes(".//*[@id='MainContent_ViewCashChequeRates_divCash']/div[2]/*[@class='table table-hover table-bordered table-blueheader table-responsive']");
            var innerTexts = average_banknotes_table.Select(node => node.InnerText);

            string[] lines = innerTexts.ToArray()[0].Split('\n');
            var cleanLinetitles = lines.Where(lines => !string.IsNullOrWhiteSpace(lines)).Select(x => x.Trim()).ToArray();

            //Fetch the first line of the table title
            for (int i = 0; i < 5; i++)
            {
                string row = "";
                for (int j = 0; j < 5; j++)
                {
                    row += cleanLinetitles[i + j] + '\t';
                }
                File.AppendAllText(@"SanaRate_Scrapper.txt", row + "\r\n");
                i += 4;
            }

            //Fetch the second row of the table title
            for (int i = 5; i < 12; i++)
            {
                string row = "";
                for (int j = 0; j < 6; j++)
                {
                    row += cleanLinetitles[i + j] + '\t';
                }
                File.AppendAllText(@"SanaRate_Scrapper.txt", "\t" + "\t" + "    " + row + "\r\n");
                i += 6;
            }

            //Fetch specific data from the table
            for (int i = 11; i < cleanLinetitles.Length; i++)
            {
                string row = "";
                for (int j = 0; j < 8; j++)
                {
                    row += cleanLinetitles[i + j] + '\t';
                }
                File.AppendAllText(@"SanaRate_Scrapper.txt", row + "\r\n");
                i += 7;
            }
        }`

</p>
</details>           
            
---
## Create File TXT
* Finally, put all the information you have fetched in a txt file.
<br />
 * Then it is necessary to define this information in object format and define a model for them and save it in DataBase. 
 <br />
 * Then it is necessary for Job Scheduler to place this information in the DataBase in a timed manner and to be able to control 
 <br />
 <details><summary> and manage these operations through the dashboard provided by the Job Scheduler service:</summary>
<p>

`File.AppendAllLines(@"SanaRate_Scrapper.txt", cleanLine_average_banknotes);`

</p>

  </details>

</details>

</div>

---

<div dir="ltr">

# Sources
<p>

* https://www.technologycrowds.com/

* https://html-agility-pack.net/documentation

* https://docs.microsoft.com/en-us/dotnet/api/system.io.file.appendalllines?view=net-5.0#System_IO_File_AppendAllLines_System_String_System_Collections_Generic_IEnumerable_System_String__

* http://codebuckets.com/2017/10/19/getting-the-root-directory-path-for-net-core-applications/

</p>

</div>
    
</div>

---

<div dir="ltr">

#Reference

<a href="https://alm.index-holding.com/IndexCollection/SoftDept/_wiki/wikis/SoftDept.wiki/43/SanaScrapper">SanaScrapper</a>

</div>