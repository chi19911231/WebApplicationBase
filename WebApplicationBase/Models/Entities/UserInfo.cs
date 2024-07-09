using System;
using System.Collections.Generic;

namespace WebApplicationBase.Models.Entities;

public partial class UserInfo
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 帳號
    /// </summary>
    public string? Acount { get; set; }

    /// <summary>
    /// 密碼
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 身分證
    /// </summary>
    public string? PersonId { get; set; }

    /// <summary>
    /// 性別(列舉值 1:男生 2:女生 3:其他)
    /// </summary>
    public int? Gender { get; set; }

    /// <summary>
    /// 電子信箱
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// 手機
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// 地址
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
