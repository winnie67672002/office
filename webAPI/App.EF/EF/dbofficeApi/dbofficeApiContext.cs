using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App.EF.EF.dbofficeApi
{
    public partial class dbofficeApiContext : DbContext
    {
        public dbofficeApiContext()
        {
        }

        public dbofficeApiContext(DbContextOptions<dbofficeApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAccessLog> TblAccessLog { get; set; }
        public virtual DbSet<TblApply> TblApply { get; set; }
        public virtual DbSet<TblApplyItem> TblApplyItem { get; set; }
        public virtual DbSet<TblBusinessUnit> TblBusinessUnit { get; set; }
        public virtual DbSet<TblFunction> TblFunction { get; set; }
        public virtual DbSet<TblFunctionOnBu> TblFunctionOnBu { get; set; }
        public virtual DbSet<TblFunctionOnGroup> TblFunctionOnGroup { get; set; }
        public virtual DbSet<TblGoods> TblGoods { get; set; }
        public virtual DbSet<TblLoginLog> TblLoginLog { get; set; }
        public virtual DbSet<TblSample> TblSample { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblUserGroup> TblUserGroup { get; set; }
        public virtual DbSet<TblUserOnGroup> TblUserOnGroup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-O61HUUI5\\SQLEXPRESS;Database=dbofficeApi;Trusted_Connection=False;user id=sa;password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAccessLog>(entity =>
            {
                entity.HasKey(e => e.CId);

                entity.ToTable("tblAccessLog");

                entity.Property(e => e.CId).HasColumnName("cID");

                entity.Property(e => e.CActionName)
                    .HasColumnName("cActionName")
                    .HasMaxLength(50)
                    .HasComment(@"{
  ""isquery"":1,
  ""isRequire"":1,
  ""columnDesc"":""動作名稱""
}");

                entity.Property(e => e.CApiname)
                    .HasColumnName("cAPIName")
                    .HasMaxLength(50)
                    .HasComment("API");

                entity.Property(e => e.CCreateDt)
                    .HasColumnName("cCreateDT")
                    .HasColumnType("datetime")
                    .HasComment("建立日期");

                entity.Property(e => e.CCreator)
                    .HasColumnName("cCreator")
                    .HasMaxLength(20)
                    .HasComment("建立者Id");

                entity.Property(e => e.CFunctionId)
                    .HasColumnName("cFunctionID")
                    .HasComment(@"{
  ""isquery"":1,
  ""type"":""dropdownlist"",
  ""options"":[{""text"":""功能1"",""value"":""1""},{""text"":""功能2"",""value"":""2""},{""text"":""功能3"",""value"":""3""}],
  ""columnDesc"":""功能""
}");

                entity.Property(e => e.CIp)
                    .HasColumnName("cIP")
                    .HasMaxLength(50)
                    .HasComment("IP");

                entity.Property(e => e.CRemark)
                    .HasColumnName("cRemark")
                    .HasMaxLength(500)
                    .HasComment("備註");

                entity.Property(e => e.CRequest)
                    .HasColumnName("cRequest")
                    .HasComment("請求參數");

                entity.Property(e => e.CUpdateDt)
                    .HasColumnName("cUpdateDT")
                    .HasColumnType("datetime")
                    .HasComment("更新日期");

                entity.Property(e => e.CUpdator)
                    .HasColumnName("cUpdator")
                    .HasMaxLength(20)
                    .HasComment("更新者Id");

                entity.Property(e => e.CUrl)
                    .HasColumnName("cUrl")
                    .HasMaxLength(200)
                    .HasComment("URL");

                entity.Property(e => e.CUserId)
                    .HasColumnName("cUserID")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblApply>(entity =>
            {
                entity.HasKey(e => e.CId);

                entity.ToTable("tblApply");

                entity.Property(e => e.CId).HasColumnName("cID");

                entity.Property(e => e.CApplyDate)
                    .HasColumnName("cApplyDate")
                    .HasColumnType("datetime2(3)");

                entity.Property(e => e.CApplyDept)
                    .IsRequired()
                    .HasColumnName("cApplyDept")
                    .HasMaxLength(20);

                entity.Property(e => e.CApplyEmpName)
                    .IsRequired()
                    .HasColumnName("cApplyEmpName")
                    .HasMaxLength(20);

                entity.Property(e => e.CCostingNo)
                    .HasColumnName("cCostingNo")
                    .HasMaxLength(20);

                entity.Property(e => e.CFile)
                    .HasColumnName("cFile")
                    .HasMaxLength(50);

                entity.Property(e => e.CFormNo)
                    .IsRequired()
                    .HasColumnName("cFormNo")
                    .HasMaxLength(20);

                entity.Property(e => e.CRemark)
                    .HasColumnName("cRemark")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TblApplyItem>(entity =>
            {
                entity.HasKey(e => new { e.CApplyId, e.CGoodsId });

                entity.ToTable("tblApplyItem");

                entity.Property(e => e.CApplyId).HasColumnName("cApplyID");

                entity.Property(e => e.CGoodsId).HasColumnName("cGoodsID");

                entity.Property(e => e.CCount).HasColumnName("cCount");
            });

            modelBuilder.Entity<TblBusinessUnit>(entity =>
            {
                entity.HasKey(e => e.CId);

                entity.ToTable("tblBusinessUnit");

                entity.HasComment("企業主檔");

                entity.Property(e => e.CId)
                    .HasColumnName("cID")
                    .HasMaxLength(20)
                    .HasComment("BUID");

                entity.Property(e => e.CBucode)
                    .HasColumnName("cBUCode")
                    .HasMaxLength(20)
                    .HasComment("BU代碼");

                entity.Property(e => e.CCreateDt)
                    .HasColumnName("cCreateDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CCreator)
                    .HasColumnName("cCreator")
                    .HasMaxLength(20);

                entity.Property(e => e.CDescription)
                    .HasColumnName("cDescription")
                    .HasMaxLength(200)
                    .HasComment("說明");

                entity.Property(e => e.CName)
                    .HasColumnName("cName")
                    .HasMaxLength(50)
                    .HasComment("BU名稱");

                entity.Property(e => e.CPlatformIsSupport)
                    .HasColumnName("cPlatformIsSupport")
                    .HasComment("是否支援");

                entity.Property(e => e.CRemark)
                    .HasColumnName("cRemark")
                    .HasMaxLength(500)
                    .HasComment("備註");

                entity.Property(e => e.CStatus)
                    .HasColumnName("cStatus")
                    .HasComment("狀態");

                entity.Property(e => e.CType)
                    .HasColumnName("cType")
                    .HasComment("1 平台 2 商戶");

                entity.Property(e => e.CUpdateDt)
                    .HasColumnName("cUpdateDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CUpdator)
                    .HasColumnName("cUpdator")
                    .HasMaxLength(20);

                entity.Property(e => e.CUserLimit)
                    .HasColumnName("cUserLimit")
                    .HasComment("使用者上限");
            });

            modelBuilder.Entity<TblFunction>(entity =>
            {
                entity.HasKey(e => e.CId);

                entity.ToTable("tblFunction");

                entity.HasComment("單元(已審核)");

                entity.Property(e => e.CId)
                    .HasColumnName("cID")
                    .HasComment("模組編號")
                    .ValueGeneratedNever();

                entity.Property(e => e.CCompetenceType)
                    .HasColumnName("cCompetenceType")
                    .HasComment("(0:是單元, 1:新增, 2:修改, 3:檢視, 4:刪除, 5:審核)");

                entity.Property(e => e.CCreateDt)
                    .HasColumnName("cCreateDT")
                    .HasColumnType("datetime")
                    .HasComment("建立日期時間");

                entity.Property(e => e.CCreator)
                    .HasColumnName("cCreator")
                    .HasMaxLength(20)
                    .HasComment("建立者");

                entity.Property(e => e.CCssStyle)
                    .HasColumnName("cCssStyle")
                    .HasMaxLength(50)
                    .HasComment("後台CSS樣式名稱");

                entity.Property(e => e.CFlowId)
                    .HasColumnName("cFlowID")
                    .HasComment("審查流程ID");

                entity.Property(e => e.CIsDelete)
                    .HasColumnName("cIsDelete")
                    .HasComment("緩刪除(0:未刪除, 1:已刪除)");

                entity.Property(e => e.CIsMenu)
                    .HasColumnName("cIsMenu")
                    .HasComment("是否為後台目錄(0:否, 1:是)");

                entity.Property(e => e.CMenuIndex)
                    .HasColumnName("cMenuIndex")
                    .HasComment("前台及後台目錄索引值(排序由小到大)");

                entity.Property(e => e.CName)
                    .HasColumnName("cName")
                    .HasMaxLength(20)
                    .HasComment("模組名稱");

                entity.Property(e => e.CPageUrl)
                    .HasColumnName("cPageUrl")
                    .HasMaxLength(200)
                    .HasComment("功能頁面");

                entity.Property(e => e.CParentId)
                    .HasColumnName("cParentID")
                    .HasComment("父模組編號");

                entity.Property(e => e.CStatus)
                    .HasColumnName("cStatus")
                    .HasComment("狀態(0:停用, 1:啟用)");

                entity.Property(e => e.CUpdateDt)
                    .HasColumnName("cUpdateDT")
                    .HasColumnType("datetime")
                    .HasComment("修改日期時間");

                entity.Property(e => e.CUpdator)
                    .HasColumnName("cUpdator")
                    .HasMaxLength(20)
                    .HasComment("修改者");
            });

            modelBuilder.Entity<TblFunctionOnBu>(entity =>
            {
                entity.HasKey(e => new { e.CBuid, e.CFunctionId });

                entity.ToTable("tblFunctionOnBU");

                entity.HasComment("模組功能管理(對應企業)");

                entity.Property(e => e.CBuid)
                    .HasColumnName("cBUID")
                    .HasMaxLength(20);

                entity.Property(e => e.CFunctionId).HasColumnName("cFunctionID");

                entity.Property(e => e.CStatus).HasColumnName("cStatus");
            });

            modelBuilder.Entity<TblFunctionOnGroup>(entity =>
            {
                entity.HasKey(e => new { e.CUserGroupId, e.CFunctionId })
                    .HasName("PK_tblFunctionOnRole");

                entity.ToTable("tblFunctionOnGroup");

                entity.Property(e => e.CUserGroupId)
                    .HasColumnName("cUserGroupID")
                    .HasComment("使用者群組編號");

                entity.Property(e => e.CFunctionId)
                    .HasColumnName("cFunctionID")
                    .HasComment("功能編號");
            });

            modelBuilder.Entity<TblGoods>(entity =>
            {
                entity.HasKey(e => e.CId);

                entity.ToTable("tblGoods");

                entity.Property(e => e.CId).HasColumnName("cID");

                entity.Property(e => e.CGoodsName)
                    .IsRequired()
                    .HasColumnName("cGoodsName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblLoginLog>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK_tblLoginHistory");

                entity.ToTable("tblLoginLog");

                entity.Property(e => e.CId).HasColumnName("cID");

                entity.Property(e => e.CCreateDt)
                    .HasColumnName("cCreateDT")
                    .HasColumnType("datetime")
                    .HasComment("建立日期");

                entity.Property(e => e.CCreator)
                    .HasColumnName("cCreator")
                    .HasMaxLength(20)
                    .HasComment("建立者Id");

                entity.Property(e => e.CIp)
                    .HasColumnName("cIP")
                    .HasMaxLength(50);

                entity.Property(e => e.CUpdateDt)
                    .HasColumnName("cUpdateDT")
                    .HasColumnType("datetime")
                    .HasComment("更新日期");

                entity.Property(e => e.CUpdator)
                    .HasColumnName("cUpdator")
                    .HasMaxLength(20)
                    .HasComment("更新者Id");

                entity.Property(e => e.CUserId)
                    .HasColumnName("cUserID")
                    .HasMaxLength(20);

                entity.Property(e => e.CUserToken)
                    .HasColumnName("cUserToken")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TblSample>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK_tblTemplate");

                entity.ToTable("tblSample");

                entity.Property(e => e.CId)
                    .HasColumnName("cId")
                    .HasComment("Key")
                    .ValueGeneratedNever();

                entity.Property(e => e.CDescription)
                    .HasColumnName("cDescription")
                    .HasMaxLength(500)
                    .HasComment(@"{
  ""isquery"":0,
  ""isRequire"":1,
  ""columnDesc"":""必填範例""
}");

                entity.Property(e => e.CQueryBox)
                    .HasColumnName("cQueryBox")
                    .HasMaxLength(100)
                    .HasComment(@"{
  ""isquery"":1,
  ""columnDesc"":""查詢範例""
}");

                entity.Property(e => e.CStartDate)
                    .HasColumnName("cStartDate")
                    .HasColumnType("datetime")
                    .HasComment("日期範例");

                entity.Property(e => e.CTitle)
                    .HasColumnName("cTitle")
                    .HasMaxLength(50)
                    .HasComment("文字框範例");

                entity.Property(e => e.CType)
                    .IsRequired()
                    .HasColumnName("cType")
                    .HasMaxLength(10)
                    .HasComment(@"{
  ""isquery"":1,
  ""isRequire"":1,
  ""type"":""dropdownlist"",
  ""options"":[{""text"":""功能1"",""value"":""T1""},{""text"":""功能2"",""value"":""T2""},{""text"":""功能3"",""value"":""T3""}],
  ""columnDesc"":""下拉範例""
}");

                entity.Property(e => e.CType2)
                    .HasColumnName("cType2")
                    .HasMaxLength(100)
                    .HasComment(@"{
  ""isquery"":0,
  ""isRequire"":1,
  ""type"":""dropdownlist"",
  ""options"":[{""text"":""B功能1"",""value"":""T1""},{""text"":""B功能2"",""value"":""T2""},{""text"":""B功能3"",""value"":""T3""}],
  ""columnDesc"":""下拉範例2""
}");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.CUserId);

                entity.ToTable("tblUser");

                entity.HasComment("使用者");

                entity.Property(e => e.CUserId)
                    .HasColumnName("cUserID")
                    .HasMaxLength(20)
                    .HasComment("使用者編號編號");

                entity.Property(e => e.CAccount)
                    .HasColumnName("cAccount")
                    .HasMaxLength(100)
                    .HasComment("cAccount、cAccount2都不可重複");

                entity.Property(e => e.CAgentUnit)
                    .HasColumnName("cAgentUnit")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("代理單位");

                entity.Property(e => e.CBuid)
                    .HasColumnName("cBUID")
                    .HasMaxLength(20)
                    .HasComment("BU");

                entity.Property(e => e.CCreateDt)
                    .HasColumnName("cCreateDT")
                    .HasColumnType("datetime")
                    .HasComment("建立日期時間");

                entity.Property(e => e.CCreator)
                    .HasColumnName("cCreator")
                    .HasMaxLength(20)
                    .HasComment("建立者");

                entity.Property(e => e.CIsDelete)
                    .HasColumnName("cIsDelete")
                    .HasComment("緩刪除(0:未刪除, 1:已刪除)");

                entity.Property(e => e.CIsDeptManager)
                    .HasColumnName("cIsDeptManager")
                    .HasComment("是否為單位最高權限(0:否, 1:是)");

                entity.Property(e => e.CMail)
                    .HasColumnName("cMail")
                    .HasMaxLength(254)
                    .HasComment("信箱");

                entity.Property(e => e.CPassword)
                    .HasColumnName("cPassword")
                    .HasComment("密碼");

                entity.Property(e => e.CStatus)
                    .HasColumnName("cStatus")
                    .HasComment("狀態 0:停用 1:啟用");

                entity.Property(e => e.CUpdateDt)
                    .HasColumnName("cUpdateDT")
                    .HasColumnType("datetime")
                    .HasComment("更新日期時間");

                entity.Property(e => e.CUpdator)
                    .HasColumnName("cUpdator")
                    .HasMaxLength(20)
                    .HasComment("更新者");

                entity.Property(e => e.CUserName)
                    .HasColumnName("cUserName")
                    .HasMaxLength(50)
                    .HasComment("使用者名稱");
            });

            modelBuilder.Entity<TblUserGroup>(entity =>
            {
                entity.HasKey(e => e.CId);

                entity.ToTable("tblUserGroup");

                entity.HasComment("使用者群組");

                entity.Property(e => e.CId)
                    .HasColumnName("cID")
                    .HasComment("使用者群組編號");

                entity.Property(e => e.CBuid)
                    .HasColumnName("cBUID")
                    .HasMaxLength(20);

                entity.Property(e => e.CCreateDt)
                    .HasColumnName("cCreateDT")
                    .HasColumnType("datetime")
                    .HasComment("建立日期時間");

                entity.Property(e => e.CCreator)
                    .HasColumnName("cCreator")
                    .HasMaxLength(20)
                    .HasComment("建立者");

                entity.Property(e => e.CName)
                    .HasColumnName("cName")
                    .HasMaxLength(100)
                    .HasComment("群組名稱");

                entity.Property(e => e.CStatus)
                    .HasColumnName("cStatus")
                    .HasComment("狀態(0:停用, 1:啟用)");

                entity.Property(e => e.CUpdateDt)
                    .HasColumnName("cUpdateDT")
                    .HasColumnType("datetime")
                    .HasComment("更新日期時間");

                entity.Property(e => e.CUpdator)
                    .HasColumnName("cUpdator")
                    .HasMaxLength(20)
                    .HasComment("更新者");
            });

            modelBuilder.Entity<TblUserOnGroup>(entity =>
            {
                entity.HasKey(e => new { e.CUserId, e.CUserGroupId });

                entity.ToTable("tblUserOnGroup");

                entity.Property(e => e.CUserId)
                    .HasColumnName("cUserID")
                    .HasMaxLength(50);

                entity.Property(e => e.CUserGroupId).HasColumnName("cUserGroupID");

                entity.Property(e => e.CStatus).HasColumnName("cStatus");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
