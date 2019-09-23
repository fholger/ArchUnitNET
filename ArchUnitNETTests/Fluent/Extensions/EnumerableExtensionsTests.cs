﻿using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Fluent.Extensions;
using ArchUnitNETTests.Domain;
using Xunit;
using static System.Environment;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ArchUnitNETTests.Fluent.Extensions
{
    public class EnumerableExtensionsTests
    {
        private static readonly Architecture Architecture = StaticTestArchitectures.ArchUnitNETTestArchitecture;
        private const string NoClassName = "NotTheNameOfAnyClass_1592479214";

        private static readonly IArchRule TrueArchRule1 = Classes().That().ArePrivate().Should().BePrivate();
        private static readonly IArchRule TrueArchRule2 = Members().Should().Exist();

        private static readonly IArchRule WrongArchRule1 =
            Classes().That().Are(StaticTestTypes.PublicTestClass).Should().BePrivate();

        private static readonly IArchRule WrongArchRule2 = Classes().That().Are(StaticTestTypes.PublicTestClass)
            .Should().BePrivate().AndShould().BePublic();

        private static readonly IArchRule WrongArchRule3 = Classes().That().Are(StaticTestTypes.PublicTestClass)
            .Should().BePrivate().AndShould().BePublic().OrShould().BeProtected();

        private static readonly IArchRule WrongArchRule4 = Classes().That().HaveName(NoClassName).Should().Exist();

        private static readonly IArchRule WrongArchRule5 =
            Classes().That().HaveName(NoClassName).Should().BePrivate().AndShould().Exist();

        private static readonly IArchRule WrongArchRule6 =
            Classes().That().Are(StaticTestTypes.PublicTestClass).Should().NotExist();

        private static readonly IArchRule WrongArchRule7 = Classes().That().Are(StaticTestTypes.PublicTestClass)
            .Should().NotExist().AndShould().BePublic();

        private static readonly IArchRule WrongArchRule8 = Classes().That().Are(StaticTestTypes.PublicTestClass)
            .Should().NotExist().OrShould().BePrivate();

        private static readonly IArchRule WrongArchRule1AndWrongArchRule3 = WrongArchRule1.And(WrongArchRule3);
        private static readonly IArchRule WrongArchRule4AndWrongArchRule8 = WrongArchRule4.And(WrongArchRule8);

        private const string ExpectedTrueArchRuleErrorMessage = "All Evaluations passed";

        private readonly string _expectedWrongArchRule1ErrorMessage =
            "\"Classes that are \"ArchUnitNETTests.Domain.PublicTestClass\" should be private\" failed:" +
            NewLine + "\tArchUnitNETTests.Domain.PublicTestClass is not private" + NewLine +
            NewLine;


        private readonly string _expectedWrongArchRule2ErrorMessage =
            "\"Classes that are \"ArchUnitNETTests.Domain.PublicTestClass\" should be private and should be public\" failed:" +
            NewLine + "\tArchUnitNETTests.Domain.PublicTestClass is not private" + NewLine +
            NewLine;

        private readonly string _expectedWrongArchRule3ErrorMessage =
            "\"Classes that are \"ArchUnitNETTests.Domain.PublicTestClass\" should be private and should be public or should be protected\" failed:" +
            NewLine + "\tArchUnitNETTests.Domain.PublicTestClass is not private and is not protected" +
            NewLine + NewLine;

        private readonly string _expectedWrongArchRule4ErrorMessage =
            "\"Classes that have name \"NotTheNameOfAnyClass_1592479214\" should exist\" failed:" +
            NewLine + "\tThere are no objects matching the criteria" + NewLine +
            NewLine;

        private readonly string _expectedWrongArchRule5ErrorMessage =
            "\"Classes that have name \"NotTheNameOfAnyClass_1592479214\" should be private and should exist\" failed:" +
            NewLine + "\tThere are no objects matching the criteria" + NewLine +
            NewLine;

        private readonly string _expectedWrongArchRule6ErrorMessage =
            "\"Classes that are \"ArchUnitNETTests.Domain.PublicTestClass\" should not exist\" failed:" +
            NewLine + "\tArchUnitNETTests.Domain.PublicTestClass does exist" + NewLine +
            NewLine;

        private readonly string _expectedWrongArchRule7ErrorMessage =
            "\"Classes that are \"ArchUnitNETTests.Domain.PublicTestClass\" should not exist and should be public\" failed:" +
            NewLine + "\tArchUnitNETTests.Domain.PublicTestClass does exist" + NewLine +
            NewLine;

        private readonly string _expectedWrongArchRule8ErrorMessage =
            "\"Classes that are \"ArchUnitNETTests.Domain.PublicTestClass\" should not exist or should be private\" failed:" +
            NewLine + "\tArchUnitNETTests.Domain.PublicTestClass does exist and is not private" +
            NewLine + NewLine;

        private readonly string _expectedWrongArchRule1AndWrongArchRule3ErrorMessage =
            "\"Classes that are \"ArchUnitNETTests.Domain.PublicTestClass\" should be private\" failed:" +
            NewLine + "\tArchUnitNETTests.Domain.PublicTestClass is not private" + NewLine +
            NewLine +
            "\"Classes that are \"ArchUnitNETTests.Domain.PublicTestClass\" should be private and should be public or should be protected\" failed:" +
            NewLine + "\tArchUnitNETTests.Domain.PublicTestClass is not private and is not protected" +
            NewLine + NewLine;

        private readonly string _expectedWrongArchRule4AndWrongArchRule8ErrorMessage =
            "\"Classes that have name \"NotTheNameOfAnyClass_1592479214\" should exist\" failed:" +
            NewLine + "\tThere are no objects matching the criteria" + NewLine +
            NewLine +
            "\"Classes that are \"ArchUnitNETTests.Domain.PublicTestClass\" should not exist or should be private\" failed:" +
            NewLine + "\tArchUnitNETTests.Domain.PublicTestClass does exist and is not private" +
            NewLine + NewLine;


        [Fact]
        public void CreateErrorMessageTest()
        {
            Assert.Equal(ExpectedTrueArchRuleErrorMessage, TrueArchRule1.Evaluate(Architecture).ToErrorMessage());
            Assert.Equal(ExpectedTrueArchRuleErrorMessage, TrueArchRule1.Evaluate(Architecture).ToErrorMessage());
            Assert.Equal(_expectedWrongArchRule1ErrorMessage, WrongArchRule1.Evaluate(Architecture).ToErrorMessage());
            Assert.Equal(_expectedWrongArchRule2ErrorMessage, WrongArchRule2.Evaluate(Architecture).ToErrorMessage());
            Assert.Equal(_expectedWrongArchRule3ErrorMessage, WrongArchRule3.Evaluate(Architecture).ToErrorMessage());
            Assert.Equal(_expectedWrongArchRule4ErrorMessage, WrongArchRule4.Evaluate(Architecture).ToErrorMessage());
            Assert.Equal(_expectedWrongArchRule5ErrorMessage, WrongArchRule5.Evaluate(Architecture).ToErrorMessage());
            Assert.Equal(_expectedWrongArchRule6ErrorMessage, WrongArchRule6.Evaluate(Architecture).ToErrorMessage());
            Assert.Equal(_expectedWrongArchRule7ErrorMessage, WrongArchRule7.Evaluate(Architecture).ToErrorMessage());
            Assert.Equal(_expectedWrongArchRule8ErrorMessage, WrongArchRule8.Evaluate(Architecture).ToErrorMessage());
            Assert.Equal(_expectedWrongArchRule1AndWrongArchRule3ErrorMessage,
                WrongArchRule1AndWrongArchRule3.Evaluate(Architecture).ToErrorMessage());
            Assert.Equal(_expectedWrongArchRule4AndWrongArchRule8ErrorMessage,
                WrongArchRule4AndWrongArchRule8.Evaluate(Architecture).ToErrorMessage());
        }
    }
}