using Assessment.Domain;
using Framework.Validation;
using Framework.Validation.CommonRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.SendTerminal
{
    #region Shared

    [RuleForProperty("Content")]
    public class MessageRequiredProperties : RequiredRule<Message>
    {
        #region Constructors

        public MessageRequiredProperties(Message owner)
            : base(owner)
        {
        }

        #endregion
    }

    [RuleForProperty("Content")]
    public class MessageNoEmptyStringRuleProperties : NoEmptyStringRule<Message>
    {
        #region Constructors

        public MessageNoEmptyStringRuleProperties(Message owner)
            : base(owner)
        {
        }

        #endregion
    }

    #endregion
}
