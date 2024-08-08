using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Recruitment.API.Models
{
    public class New
    {
        public int NewId { get; set; }

        [Comment("Tiêu đề")]
        [MaxLength(250)]
        public string Title { get; set; }

        [Comment("Mô tả ngắn gọn")]
        [Column(TypeName = "ntext")]
        public string Quote { get; set; }

        [Comment("Chi tiết")]
        public string Detail { get; set; }

        [Comment("Ngày đăng")]
        [Column(TypeName = "datetime")]
        public DateTime? PostDate { get; set; }

        [Comment("Ngày duyệt")]
        [Column(TypeName = "datetime")]
        public DateTime? PublicDate { get; set; }

        [Comment("Thể loại")]
        public int? Type { get; set; }

        [Comment("Mã người đăng")]
        public int? WebmasterId { get; set; }

        [Comment("Mã chuyên mục")]
        public int? CategoryId { get; set; }

        [Comment("Trạng thái")]
        public int? Status { get; set; }

        [Comment("Ảnh đại diện")]
        [Column(TypeName = "ntext")]
        public string Avatar { get; set; }

        public virtual Category Category { get; set; }
        public virtual Webmaster Webmaster { get; set; }
    }
}