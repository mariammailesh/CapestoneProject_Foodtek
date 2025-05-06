using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapestoneProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_NameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category_NameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__6DB38D6ED9EC75C4", x => x.Category_Id);
                });

            migrationBuilder.CreateTable(
                name: "Lookup_Types",
                columns: table => new
                {
                    TYPE_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_En = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name_Ar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Creation_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lookup_T__41F99A32A2710A8C", x => x.TYPE_Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Option_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Ar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name_En = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OptionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Is_Required = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Creation_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Options__3260907E7BD27D43", x => x.Option_Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Permission_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Permissi__89B74485C2324BA6", x => x.Permission_Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Ar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name_En = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__D80AB4BB9468D958", x => x.Role_Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Item_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    Name_Ar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name_En = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description_Ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Creation_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Items__3FB50874D4819B4C", x => x.Item_Id);
                    table.ForeignKey(
                        name: "FK__Items__Category___628FA481",
                        column: x => x.Category_Id,
                        principalTable: "Categories",
                        principalColumn: "Category_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lookup_Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_Id = table.Column<int>(type: "int", nullable: false),
                    Value_En = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value_Ar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Creation_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lookup_I__3214EC0713576D9A", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Lookup_It__Type___6B24EA82",
                        column: x => x.Type_Id,
                        principalTable: "Lookup_Types",
                        principalColumn: "TYPE_Id");
                });

            migrationBuilder.CreateTable(
                name: "Role_Permissions",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "int", nullable: false),
                    Permission_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Permissions", x => new { x.Role_Id, x.Permission_Id });
                    table.ForeignKey(
                        name: "FK__Role_Perm__Permi__56E8E7AB",
                        column: x => x.Permission_Id,
                        principalTable: "Permissions",
                        principalColumn: "Permission_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Role_Perm__Role___55F4C372",
                        column: x => x.Role_Id,
                        principalTable: "Roles",
                        principalColumn: "Role_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Id = table.Column<int>(type: "int", nullable: false),
                    Full_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password_Hash = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Profile_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birth_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__206D917003FA2063", x => x.User_Id);
                    table.ForeignKey(
                        name: "FK__Users__Role_Id__5441852A",
                        column: x => x.Role_Id,
                        principalTable: "Roles",
                        principalColumn: "Role_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    Option_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Creation_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ItemOpti__3214EC0715D65DFB", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ItemOptio__Item___74AE54BC",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Item_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ItemOptio__Optio__75A278F5",
                        column: x => x.Option_Id,
                        principalTable: "Options",
                        principalColumn: "Option_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Discount_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title_ar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    End_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Limit_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: true),
                    Discount_Status = table.Column<int>(type: "int", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discount__6C1372049EC8737D", x => x.Discount_Id);
                    table.ForeignKey(
                        name: "FK__Discounts__Disco__797309D9",
                        column: x => x.Discount_Status,
                        principalTable: "Lookup_Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Cart_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Cart_Status = table.Column<int>(type: "int", nullable: true),
                    Total_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_At = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart__D6AB4759ACB7C396", x => x.Cart_Id);
                    table.ForeignKey(
                        name: "FK__Cart__Cart_Statu__671F4F74",
                        column: x => x.Cart_Status,
                        principalTable: "Lookup_Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Cart__User_Id__662B2B3B",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Issues_Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Issue_Type = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Issues_S__3214EC076EB9F474", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Issues_Su__Issue__32AB8735",
                        column: x => x.Issue_Type,
                        principalTable: "Lookup_Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Issues_Su__User___31B762FC",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notification_Type = table.Column<int>(type: "int", nullable: true),
                    Is_Read = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3214EC07F500F7C2", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Notificat__Notif__2CF2ADDF",
                        column: x => x.Notification_Type,
                        principalTable: "Lookup_Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Notificat__User___2BFE89A6",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOTP",
                columns: table => new
                {
                    UserOTP_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OTPCode = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    TryCount = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Purpose = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "ResetPassword"),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserOTP__44938591C6B1170F", x => x.UserOTP_Id);
                    table.ForeignKey(
                        name: "FK__UserOTP__User_Id__5F7E2DAC",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateTable(
                name: "Discount_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount_Id = table.Column<int>(type: "int", nullable: true),
                    Category_Id = table.Column<int>(type: "int", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discount__3214EC07B0A34FF8", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Discount___Categ__3E1D39E1",
                        column: x => x.Category_Id,
                        principalTable: "Categories",
                        principalColumn: "Category_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Discount___Disco__3D2915A8",
                        column: x => x.Discount_Id,
                        principalTable: "Discounts",
                        principalColumn: "Discount_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discount_items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount_Id = table.Column<int>(type: "int", nullable: true),
                    Item_Id = table.Column<int>(type: "int", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discount__3214EC078D4298B4", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Discount___Disco__37703C52",
                        column: x => x.Discount_Id,
                        principalTable: "Discounts",
                        principalColumn: "Discount_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Discount___Item___3864608B",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Item_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    Driver_Id = table.Column<int>(type: "int", nullable: true),
                    Discount_Id = table.Column<int>(type: "int", nullable: true),
                    Order_Status = table.Column<int>(type: "int", nullable: true),
                    Total_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_At = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__F1E4607B19E05042", x => x.Order_Id);
                    table.ForeignKey(
                        name: "FK__Orders__Client_I__7C4F7684",
                        column: x => x.Client_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                    table.ForeignKey(
                        name: "FK__Orders__Discount__00200768",
                        column: x => x.Discount_Id,
                        principalTable: "Discounts",
                        principalColumn: "Discount_Id");
                    table.ForeignKey(
                        name: "FK__Orders__Driver_I__7D439ABD",
                        column: x => x.Driver_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                    table.ForeignKey(
                        name: "FK__Orders__Order_St__01142BA1",
                        column: x => x.Order_Status,
                        principalTable: "Lookup_Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart_Items",
                columns: table => new
                {
                    Cart_Item_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cart_Id = table.Column<int>(type: "int", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart_Ite__3C0F265CB1ADE5CC", x => x.Cart_Item_Id);
                    table.ForeignKey(
                        name: "FK__Cart_Item__Cart___6CD828CA",
                        column: x => x.Cart_Id,
                        principalTable: "Cart",
                        principalColumn: "Cart_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Cart_Item__Item___6DCC4D03",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Item_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Issues_Suggestions",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Issue_Suggestion_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Issues_Suggestions", x => new { x.User_Id, x.Issue_Suggestion_Id });
                    table.ForeignKey(
                        name: "FK__User_Issu__Issue__51300E55",
                        column: x => x.Issue_Suggestion_Id,
                        principalTable: "Issues_Suggestions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__User_Issu__User___503BEA1C",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Notifications",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Notification_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Read = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Notifications", x => new { x.User_Id, x.Notification_Id });
                    table.ForeignKey(
                        name: "FK__User_Noti__Notif__4B7734FF",
                        column: x => x.Notification_Id,
                        principalTable: "Notifications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__User_Noti__User___4A8310C6",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Chat_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    Driver_Id = table.Column<int>(type: "int", nullable: false),
                    Chat_File_Path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Creation_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Chats__9783B1DEE62FC6A8", x => x.Chat_Id);
                    table.ForeignKey(
                        name: "FK__Chats__Client_Id__0F624AF8",
                        column: x => x.Client_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                    table.ForeignKey(
                        name: "FK__Chats__Driver_Id__10566F31",
                        column: x => x.Driver_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                    table.ForeignKey(
                        name: "FK__Chats__Order_Id__1332DBDC",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryLocations",
                columns: table => new
                {
                    Location_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<int>(type: "int", nullable: true),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    Delivery_Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Delivery_Time = table.Column<DateTime>(type: "datetime", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Creation_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Delivery__D2BA00E202595D36", x => x.Location_Id);
                    table.ForeignKey(
                        name: "FK__DeliveryL__Clien__1CBC4616",
                        column: x => x.Client_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                    table.ForeignKey(
                        name: "FK__DeliveryL__Order__1F98B2C1",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Items",
                columns: table => new
                {
                    OrderItem_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<int>(type: "int", nullable: true),
                    Item_Id = table.Column<int>(type: "int", nullable: true),
                    Total_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Item_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order_It__2F30220238919D6B", x => x.OrderItem_Id);
                    table.ForeignKey(
                        name: "FK__Order_Ite__Item___06CD04F7",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Item_Id");
                    table.ForeignKey(
                        name: "FK__Order_Ite__Order__05D8E0BE",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders_History",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersHistory", x => new { x.Order_Id, x.Client_Id });
                    table.ForeignKey(
                        name: "FK__Orders_Hi__Clien__09A971A2",
                        column: x => x.Client_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                    table.ForeignKey(
                        name: "FK__Orders_Hi__Order__0C85DE4D",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Payment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<int>(type: "int", nullable: true),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    Payment_Method = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Paid_At = table.Column<DateTime>(type: "datetime", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_At = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payments__DA6C7FC12F15425C", x => x.Payment_Id);
                    table.ForeignKey(
                        name: "FK__Payments__Client__160F4887",
                        column: x => x.Client_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                    table.ForeignKey(
                        name: "FK__Payments__Order___18EBB532",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Payments__Paymen__19DFD96B",
                        column: x => x.Payment_Method,
                        principalTable: "Lookup_Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    Order_Id = table.Column<int>(type: "int", nullable: true),
                    Driver_Id = table.Column<int>(type: "int", nullable: false),
                    Rating_Amount = table.Column<double>(type: "float", nullable: true),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ratings__3214EC07574E2397", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Ratings__Client___22751F6C",
                        column: x => x.Client_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                    table.ForeignKey(
                        name: "FK__Ratings__Driver___236943A5",
                        column: x => x.Driver_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                    table.ForeignKey(
                        name: "FK__Ratings__Order_I__2645B050",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: true),
                    Item_Id = table.Column<int>(type: "int", nullable: true),
                    Order_Id = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Created_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reports__3214EC078EE098FD", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Reports__Item_Id__43D61337",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Item_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Reports__Order_I__44CA3770",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Reports__User_Id__42E1EEFE",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Cart_Status",
                table: "Cart",
                column: "Cart_Status");

            migrationBuilder.CreateIndex(
                name: "UQ__Cart__206D91712162912E",
                table: "Cart",
                column: "User_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Items_Cart_Id",
                table: "Cart_Items",
                column: "Cart_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Items_Item_Id",
                table: "Cart_Items",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_Client_Id",
                table: "Chats",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_Driver_Id",
                table: "Chats",
                column: "Driver_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_Order_Id",
                table: "Chats",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryLocations_Client_Id",
                table: "DeliveryLocations",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryLocations_Order_Id",
                table: "DeliveryLocations",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_Categories_Category_Id",
                table: "Discount_Categories",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_Categories_Discount_Id",
                table: "Discount_Categories",
                column: "Discount_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_items_Discount_Id",
                table: "Discount_items",
                column: "Discount_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_items_Item_Id",
                table: "Discount_items",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_Discount_Status",
                table: "Discounts",
                column: "Discount_Status");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_Suggestions_Issue_Type",
                table: "Issues_Suggestions",
                column: "Issue_Type");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_Suggestions_User_Id",
                table: "Issues_Suggestions",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOptions_Item_Id",
                table: "ItemOptions",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOptions_Option_Id",
                table: "ItemOptions",
                column: "Option_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Category_Id",
                table: "Items",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_Items_Type_Id",
                table: "Lookup_Items",
                column: "Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_Notification_Type",
                table: "Notifications",
                column: "Notification_Type");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_User_Id",
                table: "Notifications",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_Item_Id",
                table: "Order_Items",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_Order_Id",
                table: "Order_Items",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Client_Id",
                table: "Orders",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Discount_Id",
                table: "Orders",
                column: "Discount_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Driver_Id",
                table: "Orders",
                column: "Driver_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Order_Status",
                table: "Orders",
                column: "Order_Status");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_History_Client_Id",
                table: "Orders_History",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Client_Id",
                table: "Payments",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Order_Id",
                table: "Payments",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Payment_Method",
                table: "Payments",
                column: "Payment_Method");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Client_Id",
                table: "Ratings",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Driver_Id",
                table: "Ratings",
                column: "Driver_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Order_Id",
                table: "Ratings",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Item_Id",
                table: "Reports",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Order_Id",
                table: "Reports",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_User_Id",
                table: "Reports",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permissions_Permission_Id",
                table: "Role_Permissions",
                column: "Permission_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Issues_Suggestions_Issue_Suggestion_Id",
                table: "User_Issues_Suggestions",
                column: "Issue_Suggestion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Notifications_Notification_Id",
                table: "User_Notifications",
                column: "Notification_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserOTP_User_Id",
                table: "UserOTP",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "UQ__UserOTP__A9D10534BCE8D409",
                table: "UserOTP",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Role_Id",
                table: "Users",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__17A35CA49DB8C3C0",
                table: "Users",
                column: "Phone_Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__31C827963597F0F0",
                table: "Users",
                column: "Password_Hash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D105341D5365BB",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__C9F28456FF38F0BB",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart_Items");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "DeliveryLocations");

            migrationBuilder.DropTable(
                name: "Discount_Categories");

            migrationBuilder.DropTable(
                name: "Discount_items");

            migrationBuilder.DropTable(
                name: "ItemOptions");

            migrationBuilder.DropTable(
                name: "Order_Items");

            migrationBuilder.DropTable(
                name: "Orders_History");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Role_Permissions");

            migrationBuilder.DropTable(
                name: "User_Issues_Suggestions");

            migrationBuilder.DropTable(
                name: "User_Notifications");

            migrationBuilder.DropTable(
                name: "UserOTP");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Issues_Suggestions");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Lookup_Items");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Lookup_Types");
        }
    }
}
