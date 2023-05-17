// <copyright file="EvbException.cs" company="BahaBulle">
//     Copyright (c) BahaBulle. All rights reserved.
// </copyright>

namespace OTT.Actions.EVB
{
    using System;
    using System.Runtime.Serialization;

    internal class EvbException : Exception
    {
        protected EvbException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public EvbException()
            : base()
        {
        }

        public EvbException(string message)
            : base(message)
        {
        }

        public EvbException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
