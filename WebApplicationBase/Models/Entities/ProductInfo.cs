using System;
using System.Collections.Generic;

namespace WebApplicationBase.Models.Entities;

public partial class ProductInfo
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 身分證
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// 性別(列舉值 1:男生 2:女生 3:其他)
    /// </summary>
    public int? Type { get; set; }

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
