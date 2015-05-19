// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Xunit;

namespace Microsoft.AspNet.Razor.Generator
{
    public class AddImportCodeGeneratorTest
    {
        public static TheoryData<AddImportCodeGenerator, AddImportCodeGenerator> MatchingTestDataSet
        {
            get
            {
                return new TheoryData<AddImportCodeGenerator, AddImportCodeGenerator>
                {
                    {
                        new AddImportCodeGenerator(ns: null),
                        new AddImportCodeGenerator(ns: null)
                    },
                    {
                        new AddImportCodeGenerator(ns: "Fred"),
                        new AddImportCodeGenerator(ns: "Fred")
                    },
                };
            }
        }

        public static TheoryData<AddImportCodeGenerator, object> NonMatchingTestDataSet
        {
            get
            {
                return new TheoryData<AddImportCodeGenerator, object>
                {
                    {
                        new AddImportCodeGenerator(ns: null),
                        null
                    },
                    {
                        new AddImportCodeGenerator(ns: "Fred"),
                        null
                    },
                    {
                        new AddImportCodeGenerator(ns: "Fred"),
                        new object()
                    },
                    {
                        new AddImportCodeGenerator(ns: "Fred"),
                        SpanCodeGenerator.Null
                    },
                    {
                        new AddImportCodeGenerator(ns: "Fred"),
                        new StatementCodeGenerator()
                    },
                    {
                        // Different Namespace.
                        new AddImportCodeGenerator(ns: "Fred"),
                        new AddImportCodeGenerator(ns: "Ginger")
                    },
                    {
                        // Different Namespace (case sensitive).
                        new AddImportCodeGenerator(ns: "fred"),
                        new AddImportCodeGenerator(ns: "FRED")
                    }
                };
            }
        }

        [Theory]
        [MemberData(nameof(MatchingTestDataSet))]
        public void Equals_True_WhenExpected(AddImportCodeGenerator leftObject, AddImportCodeGenerator rightObject)
        {
            // Arrange & Act
            var result = leftObject.Equals(rightObject);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(NonMatchingTestDataSet))]
        public void Equals_False_WhenExpected(AddImportCodeGenerator leftObject, object rightObject)
        {
            // Arrange & Act
            var result = leftObject.Equals(rightObject);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(MatchingTestDataSet))]
        public void GetHashCode_ReturnsSameValue_WhenEqual(
            AddImportCodeGenerator leftObject,
            AddImportCodeGenerator rightObject)
        {
            // Arrange & Act
            var leftResult = leftObject.GetHashCode();
            var rightResult = rightObject.GetHashCode();

            // Assert
            Assert.Equal(leftResult, rightResult);
        }
    }
}
