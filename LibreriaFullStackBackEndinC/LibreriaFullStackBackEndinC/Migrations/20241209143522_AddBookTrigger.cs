using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaFullStackBackEndinC.Migrations
{
    /// <inheritdoc />
    public partial class AddBookTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
    CREATE TRIGGER TrgAfterInsertBook
    ON Books
    AFTER INSERT
    AS
    BEGIN
        DECLARE @BookID INT;
        DECLARE @Title NVARCHAR(50);

        -- Obtener los valores de la fila insertada
        SELECT @BookID = id, @Title = title FROM inserted;

        -- Insertar el registro en la tabla de auditoría
        INSERT INTO AuditLog (BookId, LogMessage)
        VALUES (@BookID, 'Nuevo librito added: ' + @Title);
    END;
    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS TrgAfterInsertBook;");
        }


    }
}
