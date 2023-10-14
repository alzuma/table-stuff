using TableResponseDemo.Models;

namespace TableResponseDemo;

public enum PayloadType
{
    Row,
    Rows,
}

public class TableResponse<T>
{
    private T Payload { get; set; }
    private Meta Meta { get; set; }

    private object _response;

    private TableResponse()
    {
        // private constructor to force the use of the builder
    }

    public object Response => _response;

    public class Builder
    {
        private readonly TableResponse<T> _tableResponse = new();

        public Builder WithRows(T rows)
        {
            _tableResponse.Payload = rows;
            return this;
        }

        public Builder WithMeta(Meta meta)
        {
            _tableResponse.Meta = meta;
            return this;
        }

        public TableResponse<T> BuildRows(bool rowsOnly) => Build(rowsOnly, PayloadType.Rows);
        public TableResponse<T> BuildRow(bool rowsOnly) => Build(rowsOnly, PayloadType.Row);

        private TableResponse<T> Build(bool rowsOnly, PayloadType payloadType)
        {
            if (_tableResponse.Payload == null)
            {
                throw new ArgumentNullException(nameof(_tableResponse.Payload));
            }

            if (rowsOnly)
            {
                _tableResponse._response = _tableResponse.Payload;
                return _tableResponse;
            }

            return payloadType switch
            {
                PayloadType.Row => PugRow(_tableResponse),
                PayloadType.Rows => PugRows(_tableResponse),
                _ => throw new ArgumentException(nameof(payloadType))
            };
        }

        private TableResponse<T> PugRow(TableResponse<T> tableResponse)
        {
            tableResponse._response = new
            {
                row = tableResponse.Payload,
                meta = tableResponse.Meta
            };
            return tableResponse;
        }

        private TableResponse<T> PugRows(TableResponse<T> tableResponse)
        {
            tableResponse._response = new
            {
                rows = tableResponse.Payload,
                meta = tableResponse.Meta
            };
            return tableResponse;
        }
    }
}