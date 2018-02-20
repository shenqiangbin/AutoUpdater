/*****************************************************************
 * Copyright (C) Knights Warrior Corporation. All rights reserved.
 * 
 * Author:   圣殿骑士（Knights Warrior） 
 * Email:    KnightsWarrior@msn.com
 * Website:  http://www.cnblogs.com/KnightsWarrior/       http://knightswarrior.blog.51cto.com/
 * Create Date:  5/8/2010 
 * Usage:
 *
 * RevisionHistory
 * Date         Author               Description
 * 
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsWarriorAutoupdater
{
    public class ConstFile
    {
        public const string TEMPFOLDERNAME = "TempFolder";
        public const string CONFIGFILEKEY = "config_";
        public const string FILENAME = "AutoUpdater.config";
        public const string ROOLBACKFILE = "KnightsWarrior.exe";
        public const string MESSAGETITLE = "自动更新程序";
        public const string CANCELORNOT = "更新程序正在运行，是否取消?";
        public const string APPLYTHEUPDATE = "应用需要重启，点击确定重新启动!";
        public const string NOTNETWORK = "应用更新失败，请重试。";
    }
}
