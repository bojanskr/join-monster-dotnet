using System;
using System.Collections.Generic;
using FluentAssertions;
using GraphQL;
using JoinMonster.Builders;
using JoinMonster.Configs;
using JoinMonster.Language.AST;
using Xunit;

namespace JoinMonster.Tests.Unit.Builders
{
    public class SqlBatchConfigBuilderTests
    {
        [Fact]
        public void Create_WhenThisKeyIsNull_ThrowsException()
        {
            Action action = () => SqlBatchConfigBuilder.Create(null, null);

            action.Should()
                .Throw<ArgumentNullException>()
                .Which.ParamName.Should()
                .Be("thisKey");
        }

        [Fact]
        public void Create_WhenParentKeyIsNull_ThrowsException()
        {
            Action action = () => SqlBatchConfigBuilder.Create("friend_id", null);

            action.Should()
                .Throw<ArgumentNullException>()
                .Which.ParamName.Should()
                .Be("parentKey");
        }

        [Fact]
        public void Create_WithThisKey_SetsThisKey()
        {
            var thisKey = "friend_id";
            var builder = SqlBatchConfigBuilder.Create(thisKey, "id");

            builder.SqlBatchConfig.ThisKey.Should().Be(thisKey);
        }

        [Fact]
        public void Create_WithParentKey_SetsParentKey()
        {
            var parentKey = "id";
            var builder = SqlBatchConfigBuilder.Create("friend_id", parentKey);

            builder.SqlBatchConfig.ParentKey.Should().Be(parentKey);
        }
    }
}
