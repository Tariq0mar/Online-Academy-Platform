namespace Online_Academy_Platform.Application.DTOs.Lectures.Requests;

public class ReorderLecturesRequest
{
    public required IReadOnlyList<LectureOrderItem> Items { get; set; }
}

public class LectureOrderItem
{
    public int LectureId { get; set; }

    public int NewOrder { get; set; }
}