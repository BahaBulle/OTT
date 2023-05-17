// <copyright file="IExtractArguments.cs" company="BahaBulle">
//     Copyright (c) BahaBulle. All rights reserved.
// </copyright>

namespace OTT
{
    using System.Collections.Generic;

    public interface IExtractArguments
    {
        string Directory { get; set; }

        IEnumerable<string> FilesList { get; }

        EnumFileTypes FileType { get; set; }
    }
}