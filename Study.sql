USE [Study]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 30.09.2022 15:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Properties] [nvarchar](max) NULL,
	[Exception] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 30.09.2022 15:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Brand] [nvarchar](max) NULL,
	[Model] [nvarchar](max) NULL,
	[CapacityKG] [int] NULL,
	[CapacityM3] [int] NULL,
	[Plate] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[ModelYear] [int] NULL,
	[Color] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Log] ON 

INSERT [dbo].[Log] ([ID], [Properties], [Exception], [CreateDate]) VALUES (1, N'ListVehicle', N'e', CAST(N'2022-09-29 14:23:22.000' AS DateTime))
INSERT [dbo].[Log] ([ID], [Properties], [Exception], [CreateDate]) VALUES (2, N'AddVehicle | Brand :  ; Model :  ; CapacityKG :  ; CapacityM3 :  ; Plate :  ; Type :  ; ModelYear :  ; Color :  ; ', N'System.Data.SqlClient.SqlException (0x80131904): The parameterized query ''(@Brand nvarchar(4000),@Model nvarchar(4000),@CapacityKg nvarcha'' expects the parameter ''@Brand'', which was not supplied.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, Boolean sendToPipe, Int32 timeout, Boolean asyncWrite, String methodName)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at StudyVehicle.Controllers.VehicleController.AddVehicle(Vehicle vehicle) in C:\Users\Recep.Aydin\source\repos\StudyVehicle\StudyVehicle\Controllers\VehicleController.cs:line 41
ClientConnectionId:039d03b3-100e-4e9e-b537-34a920b966d1
Error Number:8178,State:1,Class:16', CAST(N'2022-09-29 14:33:47.000' AS DateTime))
INSERT [dbo].[Log] ([ID], [Properties], [Exception], [CreateDate]) VALUES (3, N'AddVehicle | Brand :  ; Model :  ; CapacityKG :  ; CapacityM3 :  ; Plate :  ; Type :  ; ModelYear :  ; Color :  ; ', N'System.Data.SqlClient.SqlException (0x80131904): The parameterized query ''(@Brand nvarchar(4000),@Model nvarchar(4000),@CapacityKg nvarcha'' expects the parameter ''@Brand'', which was not supplied.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, Boolean sendToPipe, Int32 timeout, Boolean asyncWrite, String methodName)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at StudyVehicle.Controllers.VehicleController.AddVehicle(Vehicle vehicle) in C:\Users\Recep.Aydin\source\repos\StudyVehicle\StudyVehicle\Controllers\VehicleController.cs:line 41
ClientConnectionId:011081f9-a250-4186-b18a-7decb5f98bf1
Error Number:8178,State:1,Class:16', CAST(N'2022-09-29 14:36:21.000' AS DateTime))
INSERT [dbo].[Log] ([ID], [Properties], [Exception], [CreateDate]) VALUES (4, N'AddVehicle | Brand :  ; Model :  ; CapacityKG :  ; CapacityM3 :  ; Plate :  ; Type :  ; ModelYear :  ; Color :  ; ', N'System.Data.SqlClient.SqlException (0x80131904): The parameterized query ''(@Brand nvarchar(4000),@Model nvarchar(4000),@CapacityKg nvarcha'' expects the parameter ''@Brand'', which was not supplied.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, Boolean sendToPipe, Int32 timeout, Boolean asyncWrite, String methodName)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at StudyVehicle.Controllers.VehicleController.AddVehicle(Vehicle vehicle) in C:\Users\Recep.Aydin\source\repos\StudyVehicle\StudyVehicle\Controllers\VehicleController.cs:line 41
ClientConnectionId:942739a9-bdb0-4735-8714-819d279d2f89
Error Number:8178,State:1,Class:16', CAST(N'2022-09-29 14:36:31.000' AS DateTime))
INSERT [dbo].[Log] ([ID], [Properties], [Exception], [CreateDate]) VALUES (5, N'AddVehicle | Brand :  ; Model :  ; CapacityKG :  ; CapacityM3 :  ; Plate :  ; Type :  ; ModelYear :  ; Color :  ; ', N'System.Data.SqlClient.SqlException (0x80131904): The parameterized query ''(@Brand nvarchar(4000),@Model nvarchar(4000),@CapacityKg nvarcha'' expects the parameter ''@Brand'', which was not supplied.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, Boolean sendToPipe, Int32 timeout, Boolean asyncWrite, String methodName)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at StudyVehicle.Controllers.VehicleController.AddVehicle(Vehicle vehicle) in C:\Users\Recep.Aydin\source\repos\StudyVehicle\StudyVehicle\Controllers\VehicleController.cs:line 41
ClientConnectionId:21d4b26e-2b66-47b7-9799-6c69a24d9591
Error Number:8178,State:1,Class:16', CAST(N'2022-09-29 14:37:42.000' AS DateTime))
INSERT [dbo].[Log] ([ID], [Properties], [Exception], [CreateDate]) VALUES (6, N'DeleteVehicle Plate : ', N'System.Data.SqlClient.SqlException (0x80131904): The parameterized query ''(@Plate nvarchar(4000))Delete From Vehicle Where Plate = @Plate'' expects the parameter ''@Plate'', which was not supplied.
   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, SqlDataReader ds)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, Boolean sendToPipe, Int32 timeout, Boolean asyncWrite, String methodName)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at StudyVehicle.Controllers.VehicleController.DeleteVehicle(String plate)
ClientConnectionId:cb407df0-f6fc-446e-8be8-095880f0dd64
Error Number:8178,State:1,Class:16', CAST(N'2022-09-29 14:52:47.000' AS DateTime))
INSERT [dbo].[Log] ([ID], [Properties], [Exception], [CreateDate]) VALUES (7, N'EditVehicle', N'System.NullReferenceException: Object reference not set to an instance of an object.
   at StudyVehicle.Controllers.VehicleController.EditVehicle(Vehicle vehicle) in C:\Users\Recep.Aydin\source\repos\StudyVehicle\StudyVehicle\Controllers\VehicleController.cs:line 68', CAST(N'2022-09-30 11:51:29.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Log] OFF
SET IDENTITY_INSERT [dbo].[Vehicle] ON 

INSERT [dbo].[Vehicle] ([ID], [Brand], [Model], [CapacityKG], [CapacityM3], [Plate], [Type], [ModelYear], [Color], [CreateDate]) VALUES (1, N'Volvo', N'FH16', 4500, 15, N'34TR001', N'1', 2015, N'Black ', CAST(N'2022-09-29 14:53:36.000' AS DateTime))
INSERT [dbo].[Vehicle] ([ID], [Brand], [Model], [CapacityKG], [CapacityM3], [Plate], [Type], [ModelYear], [Color], [CreateDate]) VALUES (7, N'Scania', N'v8', 5000, 17, N'34TR002', N'1', 2018, N'Black', CAST(N'2022-09-30 15:18:36.000' AS DateTime))
INSERT [dbo].[Vehicle] ([ID], [Brand], [Model], [CapacityKG], [CapacityM3], [Plate], [Type], [ModelYear], [Color], [CreateDate]) VALUES (8, N'Ford', N'1842', 4000, 12, N'34TR003', N'1', 2021, N'Black', CAST(N'2022-09-30 15:26:16.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
