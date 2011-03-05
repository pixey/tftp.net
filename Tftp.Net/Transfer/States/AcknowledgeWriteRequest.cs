﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tftp.Net.Transfer.States
{
    class AcknowledgeWriteRequest : StateThatExpectsMessagesFromDefaultEndPoint
    {
        private readonly SimpleTimer timer;

        public AcknowledgeWriteRequest(TftpTransfer context)
            : base(context) 
        {
            timer = new SimpleTimer(context.Timeout);
        }

        public override void OnStateEnter()
        {
            Context.GetConnection().Send(new Acknowledgement(0));
            timer.Restart();
        }

        public override void OnTimer()
        {
            if (timer.IsTimeout())
            {
                Context.GetConnection().Send(new Acknowledgement(0));
                timer.Restart();
            }
        }

        public override void OnData(Data command)
        {
            ITransferState nextState = new Receiving(Context);
            Context.SetState(nextState);
            nextState.OnCommand(command, Context.GetConnection().RemoteEndpoint);
        }

        public override void OnCancel()
        {
            Context.SetState(new CancelledByUser(Context));
        }

        public override void OnError(Error command)
        {
            Context.SetState(new ReceivedError(Context, command));
        }
    }
}