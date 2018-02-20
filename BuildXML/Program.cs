using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace BuildXML
{
    class Program
    {
        //获取当前目录
        //static string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        static string currentDirectory = System.Environment.CurrentDirectory;
        //服务端xml文件名称
        static string serverXmlName = "AutoupdateService.xml";
        //更新文件URL前缀
        static string url = "http://www.sqber.com/app";

        static void Main(string[] args)
        {
            //创建文档对象
            XmlDocument doc = new XmlDocument();
            //创建根节点
            XmlElement root = doc.CreateElement("updateFiles");
            //头声明
            XmlDeclaration xmldecl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(xmldecl);
            //获取当前目录对象
            DirectoryInfo dicInfo = new DirectoryInfo(currentDirectory);
            //调用递归方法组装xml文件
            PopuAllDirectory(doc, root, dicInfo);
            //追加节点
            doc.AppendChild(root);
            //保存文档
            doc.Save(serverXmlName);
        }

        //递归组装xml文件方法
        private static void PopuAllDirectory(XmlDocument doc, XmlElement root, DirectoryInfo dicInfo)
        {
            foreach (FileInfo f in dicInfo.GetFiles())
            {
                //排除当前目录中生成xml文件的工具文件
                if (f.Name != "BuildXML.exe" && f.Name != "AutoupdateService.xml")
                {
                    string path = dicInfo.FullName.Replace(currentDirectory, "").Replace("\\", "/");

                    XmlElement child = doc.CreateElement("file");
                    child.SetAttribute("path", f.Name);
                    child.SetAttribute("url", url + path + "/" + f.Name);
                    child.SetAttribute("lastver", FileVersionInfo.GetVersionInfo(f.FullName).FileVersion);
                    child.SetAttribute("size", f.Length.ToString());
                    child.SetAttribute("needRestart", "false");
                    root.AppendChild(child);
                }
            }

            foreach (DirectoryInfo di in dicInfo.GetDirectories())
                PopuAllDirectory(doc, root, di);
        }

    }
}
