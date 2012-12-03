CREATE PROCEDURE [dbo].[add_task]
	@title nvarchar(256),
	@description nvarchar(1024),
	@created_by int,
	@task_id int output
AS
	DECLARE @tmp_id TABLE (id int);

	insert into Task (Title, Description, CreatedBy)
	output inserted.TaskId into @tmp_id
	values (@title, @description, @created_by)

	select top 1 @task_id = id from @tmp_id
RETURN 0
