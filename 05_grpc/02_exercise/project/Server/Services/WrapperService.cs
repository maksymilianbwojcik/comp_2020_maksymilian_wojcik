using System;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Proto;

namespace Server
{
    public class WrapperService : Wrapper.WrapperBase
    {
        public override Task<WrapReply> WrapText(WrapRequest request, ServerCallContext context)
        {
            if (request == null) throw new NullReferenceException();

            var wrapped = "";

            var iter = 0;
            while (iter < request.Line.Length)
            {
                if ((iter + 1) % request.Columns == 0)
                {
                    wrapped += System.Environment.NewLine;
                }

                wrapped += request.Line[iter];
                iter++;
            }
            
            return Task.FromResult(new WrapReply
            {
                Text = wrapped
            });
        }
    }
}
