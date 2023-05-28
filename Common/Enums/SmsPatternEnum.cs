using System;

namespace Common.Enums
{
    public enum SmsPatternEnum
    {
        [Pattern(patternName: "MessageResultRegister")]
        ChangeUserTypeStatus = 1,
    }
    
    [AttributeUsage(AttributeTargets.Field)]
    public class Pattern : Attribute
    {
        private string _patternName { get; }

        public Pattern(string patternName)
        {
            _patternName = patternName;
        }
      
        public virtual string PatternName => _patternName;
    }
}