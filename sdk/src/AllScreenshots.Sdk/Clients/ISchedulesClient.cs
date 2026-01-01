using AllScreenshots.Sdk.Models;

namespace AllScreenshots.Sdk.Clients;

/// <summary>
/// Client for schedule operations.
/// </summary>
public interface ISchedulesClient
{
    /// <summary>
    /// Creates a new schedule.
    /// </summary>
    /// <param name="request">Create schedule request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Created schedule.</returns>
    /// <example>
    /// <code>
    /// var schedule = await client.Schedules.CreateAsync(new CreateScheduleRequest
    /// {
    ///     Name = "Daily screenshot",
    ///     Url = "https://github.com",
    ///     Schedule = "0 9 * * *" // Daily at 9 AM
    /// });
    /// </code>
    /// </example>
    Task<ScheduleResponse> CreateAsync(CreateScheduleRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all schedules.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of schedules.</returns>
    Task<ScheduleListResponse> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a schedule by ID.
    /// </summary>
    /// <param name="id">Schedule ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Schedule details.</returns>
    Task<ScheduleResponse> GetAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a schedule.
    /// </summary>
    /// <param name="id">Schedule ID.</param>
    /// <param name="request">Update request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Updated schedule.</returns>
    Task<ScheduleResponse> UpdateAsync(string id, UpdateScheduleRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a schedule.
    /// </summary>
    /// <param name="id">Schedule ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Pauses a schedule.
    /// </summary>
    /// <param name="id">Schedule ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Updated schedule.</returns>
    Task<ScheduleResponse> PauseAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Resumes a paused schedule.
    /// </summary>
    /// <param name="id">Schedule ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Updated schedule.</returns>
    Task<ScheduleResponse> ResumeAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Manually triggers a schedule execution.
    /// </summary>
    /// <param name="id">Schedule ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Updated schedule.</returns>
    Task<ScheduleResponse> TriggerAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the execution history for a schedule.
    /// </summary>
    /// <param name="id">Schedule ID.</param>
    /// <param name="limit">Maximum number of executions to return.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Execution history.</returns>
    Task<ScheduleHistoryResponse> GetHistoryAsync(string id, int? limit = null, CancellationToken cancellationToken = default);
}

/// <summary>
/// Implementation of the schedules client.
/// </summary>
internal class SchedulesClient : BaseClient, ISchedulesClient
{
    public SchedulesClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<ScheduleResponse> CreateAsync(CreateScheduleRequest request, CancellationToken cancellationToken = default)
    {
        ValidateRequest(request);
        return await PostAsync<CreateScheduleRequest, ScheduleResponse>("v1/schedules", request, cancellationToken);
    }

    public async Task<ScheduleListResponse> ListAsync(CancellationToken cancellationToken = default)
    {
        return await GetAsync<ScheduleListResponse>("v1/schedules", cancellationToken);
    }

    public async Task<ScheduleResponse> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exceptions.ValidationException("Schedule ID is required");
        }

        return await GetAsync<ScheduleResponse>($"v1/schedules/{Uri.EscapeDataString(id)}", cancellationToken);
    }

    public async Task<ScheduleResponse> UpdateAsync(string id, UpdateScheduleRequest request, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exceptions.ValidationException("Schedule ID is required");
        }

        return await PutAsync<UpdateScheduleRequest, ScheduleResponse>($"v1/schedules/{Uri.EscapeDataString(id)}", request, cancellationToken);
    }

    public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exceptions.ValidationException("Schedule ID is required");
        }

        await DeleteAsync($"v1/schedules/{Uri.EscapeDataString(id)}", cancellationToken);
    }

    public async Task<ScheduleResponse> PauseAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exceptions.ValidationException("Schedule ID is required");
        }

        return await PostAsync<ScheduleResponse>($"v1/schedules/{Uri.EscapeDataString(id)}/pause", cancellationToken);
    }

    public async Task<ScheduleResponse> ResumeAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exceptions.ValidationException("Schedule ID is required");
        }

        return await PostAsync<ScheduleResponse>($"v1/schedules/{Uri.EscapeDataString(id)}/resume", cancellationToken);
    }

    public async Task<ScheduleResponse> TriggerAsync(string id, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exceptions.ValidationException("Schedule ID is required");
        }

        return await PostAsync<ScheduleResponse>($"v1/schedules/{Uri.EscapeDataString(id)}/trigger", cancellationToken);
    }

    public async Task<ScheduleHistoryResponse> GetHistoryAsync(string id, int? limit = null, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exceptions.ValidationException("Schedule ID is required");
        }

        var path = $"v1/schedules/{Uri.EscapeDataString(id)}/history";

        if (limit.HasValue)
        {
            path += $"?limit={limit.Value}";
        }

        return await GetAsync<ScheduleHistoryResponse>(path, cancellationToken);
    }

    private static void ValidateRequest(CreateScheduleRequest request)
    {
        var errors = new List<Exceptions.ValidationError>();

        if (string.IsNullOrEmpty(request.Name))
        {
            errors.Add(new Exceptions.ValidationError("name", "Name is required"));
        }
        else if (request.Name.Length > 255)
        {
            errors.Add(new Exceptions.ValidationError("name", "Name must be at most 255 characters"));
        }

        if (string.IsNullOrEmpty(request.Url))
        {
            errors.Add(new Exceptions.ValidationError("url", "URL is required"));
        }
        else if (!request.Url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                 !request.Url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            errors.Add(new Exceptions.ValidationError("url", "URL must start with http:// or https://"));
        }

        if (string.IsNullOrEmpty(request.Schedule))
        {
            errors.Add(new Exceptions.ValidationError("schedule", "Schedule (cron expression) is required"));
        }

        if (request.RetentionDays.HasValue && (request.RetentionDays < 1 || request.RetentionDays > 365))
        {
            errors.Add(new Exceptions.ValidationError("retentionDays", "Retention days must be between 1 and 365"));
        }

        if (errors.Count > 0)
        {
            throw new Exceptions.ValidationException("Invalid schedule request", errors);
        }
    }
}
