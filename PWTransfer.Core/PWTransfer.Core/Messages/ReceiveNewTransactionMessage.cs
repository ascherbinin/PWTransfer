using System;
using MvvmCross.Plugins.Messenger;

namespace PWTransfer.Core
{
	public class ReceiveNewTransactionMessage : MvxMessage
	{
		public ReceiveNewTransactionMessage(object sender) : base(sender)
		{
			
		}
	}
}
