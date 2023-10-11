namespace APITemplate.Controllers.PingController.Data
{
    /// <summary>
    /// See if this server is running. 
    /// </summary>
    public class ApiPingResponse
    {
        public string? Hello { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
