using grate.unittests.TestInfrastructure;
using NUnit.Framework;

namespace grate.unittests.SqlServer;

[TestFixture]
[Category("SqlServer")]
public class MigrationTables: Generic.GenericMigrationTables
{
    protected override IGrateTestContext Context => GrateTestContext.SqlServer;
    
    protected override string CountTableSql(string schemaName, string tableName)
    {
        return $@"
SELECT count(table_name) FROM INFORMATION_SCHEMA.TABLES
WHERE
TABLE_SCHEMA = '{schemaName}' AND
TABLE_NAME = '{tableName}' COLLATE Latin1_General_CS_AS
";
    }
}
