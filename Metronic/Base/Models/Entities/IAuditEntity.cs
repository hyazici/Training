﻿using System;

namespace Ponera.Base.Entities
{
    public interface IAuditEntity : IEntity
    {
        bool Deleted { get; set; }

        DateTime CreateDate { get; set; }

        int CreateUserId { get; set; }

        DateTime? UpdateDate { get; set; }

        int? UpdateUserId { get; set; }
    }
}