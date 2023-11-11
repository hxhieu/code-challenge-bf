﻿namespace CodeChallengeBF.Data.Entity
{
    public class TestFormEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Id => string.Format("{0}_{1}", FirstName, LastName).ToLower();
    }
}