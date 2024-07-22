﻿using System;
using System.Collections.Generic;

namespace WebApplicationBase.Models.Entities;

public partial class AddressInfo
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }

    public int UserInfoId { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// 建立使用者
    /// </summary>
    public int? CreateUser { get; set; }

    /// <summary>
    /// 建立時間
    /// </summary>
    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// 更新使用者
    /// </summary>
    public int? UpdateUser { get; set; }

    /// <summary>
    /// 異動時間
    /// </summary>
    public DateTime? UpdateTime { get; set; }
}