namespace BackgroundJobs.API.Jobs;

public interface IJob
{
    Task DoWork();
}

