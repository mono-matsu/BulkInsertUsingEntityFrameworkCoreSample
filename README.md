# BulkInsertUsingEntityFrameworkCoreSample

Entity Framework Core で Bulk Insert をするサンプルプログラムです。
RelationalDbContextOptionsBuilder の MinBatchSize を指定することで
条件があえば Bulk Insert となります。

## 対象バージョン

ASP.NET Core Runtime 6.0.2

## 発行されるSQL

### SQL Server

```
Microsoft.EntityFrameworkCore.Database.Command: Information: Executed DbCommand (33ms) [Parameters=[@p0='?' (DbType = Guid), @p1='?' (DbType = Int32), @p2='?' (DbType = Guid), @p3='?' (DbType = Int32), @P4='?' (DbType = Int32), @p5='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
SET NOCOUNT ON;
INSERT INTO [GuidKeyModels] ([Id], [Value])
VALUES (@p0, @p1),
(@p2, @p3);
DECLARE @inserted2 TABLE ([Id] int, [_Position] [int]);
MERGE [IntKeyModels] USING (
VALUES (@P4, 0),
(@p5, 1)) AS i ([Value], _Position) ON 1=0
WHEN NOT MATCHED THEN
INSERT ([Value])
VALUES (i.[Value])
OUTPUT INSERTED.[Id], i._Position
INTO @inserted2;
```

### PostgreSQL

```
Microsoft.EntityFrameworkCore.Database.Command: Information: Executed DbCommand (52ms) [Parameters=[@p0='?' (DbType = Guid), @p1='?' (DbType = Int32), @p2='?' (DbType = Guid), @p3='?' (DbType = Int32), @P4='?' (DbType = Int32), @p5='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
INSERT INTO "GuidKeyModels" ("Id", "Value")
VALUES (@p0, @p1);
INSERT INTO "GuidKeyModels" ("Id", "Value")
VALUES (@p2, @p3);
INSERT INTO "IntKeyModels" ("Value")
VALUES (@P4)
RETURNING "Id";
INSERT INTO "IntKeyModels" ("Value")
VALUES (@p5)
RETURNING "Id";
```

### MySQL

```
Microsoft.EntityFrameworkCore.Database.Command: Information: Executed DbCommand (25ms) [Parameters=[@p0='?' (DbType = Guid), @p1='?' (DbType = Int32), @p2='?' (DbType = Guid), @p3='?' (DbType = Int32), @P4='?' (DbType = Int32), @p5='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
INSERT INTO `GuidKeyModels` (`Id`, `Value`)
VALUES (@p0, @p1),
(@p2, @p3);
INSERT INTO `IntKeyModels` (`Value`)
VALUES (@P4);
SELECT `Id`
FROM `IntKeyModels`
WHERE ROW_COUNT() = 1 AND `Id` = LAST_INSERT_ID();

INSERT INTO `IntKeyModels` (`Value`)
VALUES (@p5);
SELECT `Id`
FROM `IntKeyModels`
WHERE ROW_COUNT() = 1 AND `Id` = LAST_INSERT_ID();
```

## 記事

https://zenn.dev/mono_matsu/articles/40e74c0022b9e6