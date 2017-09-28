using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using Valit;
using Xunit;

namespace Valit.Tests.ExtensionsTests
{
    public class framework_tests
    {
        [Fact]
        public void should_pass_for_int_and_uint()
        {
            Int16 Expected = 0;

            var result = ValitRules<Model>
                .For(_model)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(m => m.Int16, _ => _
                    .IsGreaterThan(Int16.MinValue)
                    .IsLessThan(Int16.MaxValue)
                    .IsEqualTo(Expected)
                    .WithMessage("Int16"))
                .Ensure(m => m.Int32, _ => _
                    .IsGreaterThan(Int32.MinValue)
                    .IsLessThan(Int32.MaxValue)
                    .IsEqualTo(0)
                    .WithMessage("Int32"))
                .Ensure(m => m.Int64, _ => _
                    .IsGreaterThan(Int64.MinValue)
                    .IsLessThan(Int64.MaxValue)
                    .IsEqualTo(0)
                    .WithMessage("Int64"))
                .Ensure(m => m.UInt16, _ => _
                    .IsGreaterThan(UInt16.MinValue)
                    .IsLessThan(UInt16.MaxValue)
                    .IsEqualTo<Model, UInt16>(1)
                    .WithMessage("UInt16"))
                .Ensure(m => m.UInt32, _ => _
                    .IsGreaterThan(UInt32.MinValue)
                    .IsLessThan(UInt32.MaxValue)
                    .IsEqualTo<Model, UInt32>(1)
                    .WithMessage("UInt32"))
                .Ensure(m => m.UInt64, _ => _
                    .IsGreaterThan(UInt64.MinValue)
                    .IsLessThan(UInt64.MaxValue)
                    .IsEqualTo<Model, UInt64>(1)
                    .WithMessage("UInt64"))
                .Validate();

            Assert.Equal(true, result.Succeeded);
            Assert.Equal("", string.Join(", ", result.Errors ?? new string[1]));
        }

        [Fact]
        public void should_not_add_messages()
        {
            var result = ValitRules<Model>
                .For(_model)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(m => m.Int32, _ => _
                    .Required()
                    .WithMessage("Should not add message 1")
                    .When(() => false)
                    .Required()
                    .WithMessage("Should not add message 2")
                    .When(() => false)
                    .Required()
                    .WithMessage("Should not add message 3")
                    .When(() => false))
                .Validate();

            Assert.Equal(true, result.Succeeded);
            Assert.Equal("", string.Join(", ", result.Errors ?? new string[1]));
        }

        [Fact]
        public void shoud_add_message_1()
        {
            var result1 = ValitRules<Model>
                .For(_model)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(m => m.Int32, _ => _
                    .Required()
                    .WithMessage("Should add message 1")
                    .When(() => true)
                    .Required()
                    .WithMessage("Should not add message 2")
                    .When(() => false)
                    .Required()
                    .WithMessage("Should not add message 3")
                    .When(() => false))
                .Validate();

            Assert.Equal(false, result1.Succeeded);
            Assert.Equal("Should add message 1", string.Join(", ", result1.Errors ?? new string[1]));
        }

        [Fact]
        public void shoud_add_message_2()
        {
            var result = ValitRules<Model>
                .For(_model)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(m => m.Int32, _ => _
                    .Required()
                    .WithMessage("Should not add message 1")
                    .When(() => false)
                    .Required()
                    .WithMessage("Should add message 2")
                    .When(() => true)
                    .Required()
                    .WithMessage("Should not add message 3")
                    .When(() => false))
                .Validate();

            Assert.Equal(false, result.Succeeded);
            Assert.Equal("Should add message 2", string.Join(", ", result.Errors ?? new string[1]));
        }

        [Fact]
        public void shoud_add_message_1_and_2()
        {
            var result = ValitRules<Model>
                .For(_model)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(m => m.Int32, _ => _
                    .Required()
                    .WithMessage("Should add message 1")
                    .When(() => true)
                    .Required()
                    .WithMessage("Should add message 2")
                    .When(() => true)
                    .Required()
                    .WithMessage("Should not add message 3")
                    .When(() => false))
                .Validate();

            Assert.Equal(false, result.Succeeded);
            Assert.Equal("Should add message 1, Should add message 2", string.Join(", ", result.Errors ?? new string[1]));
        }

        [Fact]
        public void shoud_add_message_3()
        {
            var result = ValitRules<Model>
                .For(_model)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(m => m.Int32, _ => _
                    .Required()
                    .WithMessage("Should not add message 1")
                    .When(() => false)
                    .Required()
                    .WithMessage("Should not add message 2")
                    .When(() => false)
                    .Required()
                    .WithMessage("Should add message 3")
                    .When(() => true))
                .Validate();

            Assert.Equal(false, result.Succeeded);
            Assert.Equal("Should add message 3", string.Join(", ", result.Errors ?? new string[1]));
        }

        [Fact]
        public void shoud_add_message_1_and_3()
        {
            var result = ValitRules<Model>
                .For(_model)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(m => m.Int32, _ => _
                    .Required()
                    .WithMessage("Should add message 1")
                    .When(() => true)
                    .Required()
                    .WithMessage("Should not add message 2")
                    .When(() => false)
                    .Required()
                    .WithMessage("Should add message 3")
                    .When(() => true))
                .Validate();

            Assert.Equal(false, result.Succeeded);
            Assert.Equal("Should add message 1, Should add message 3", string.Join(", ", result.Errors ?? new string[1]));
        }

        [Fact]
        public void shoud_add_message_2_and_3()
        {
            var result = ValitRules<Model>
                .For(_model)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(m => m.Int32, _ => _
                    .Required()
                    .WithMessage("Should not add message 1")
                    .When(() => false)
                    .Required()
                    .WithMessage("Should add message 2")
                    .When(() => true)
                    .Required()
                    .WithMessage("Should add message 3")
                    .When(() => true))
                .Validate();

            Assert.Equal(false, result.Succeeded);
            Assert.Equal("Should add message 2, Should add message 3", string.Join(", ", result.Errors ?? new string[1]));
        }

        [Fact]
        public void shoud_add_message_1_and_2_and_3()
        {
            var result = ValitRules<Model>
                .For(_model)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(m => m.Int32, _ => _
                    .Required()
                    .WithMessage("Should add message 1")
                    .When(() => true)
                    .Required()
                    .WithMessage("Should add message 2")
                    .When(() => true)
                    .Required()
                    .WithMessage("Should add message 3")
                    .When(() => true))
                .Validate();

            Assert.Equal(false, result.Succeeded);
            Assert.Equal("Should add message 1, Should add message 2, Should add message 3", string.Join(", ", result.Errors ?? new string[1]));
        }

        [Fact]
        public void should_not_pass_double_required_and_when()
        {
            var result = ValitRules<Model>
                .For(_model)
                .WithStrategy(ValitRulesStrategies.Complete)
                .Ensure(m => m.Int32, _ => _
                    .Required()
                    .Required()
                    .When(() => false))
                .Validate();

            Assert.Equal(false, result.Succeeded);
        }

        public framework_tests()
        {
            _model = new Model
            {
                Int16 = 0,
                Int32 = 0,
                Int64 = 0,

                UInt16 = 1,
                UInt32 = 1,
                UInt64 = 1,

                Decimal = 0,
                Boolean = false,
                Byte = 0,

                String = "",
                OtherModel = new Model(),

                Int16List = new List<Int16>(),
                Int32List = new List<Int32>(),
                Int64List = new List<Int64>(),

                UInt16List = new List<UInt16>(),
                UInt32List = new List<UInt32>(),
                UInt64List = new List<UInt64>(),

                DecimalList = new List<Decimal>(),
                BooleanList = new List<Boolean>(),
                ByteList = new List<Byte>(),

                StringList = new List<String>(),
                OtherModelList = new List<Model>(),
            };
        }

        private Model _model;

        public class Model
        {
            public Int16 Int16 { get; set; }
            public Int32 Int32 { get; set; }
            public Int64 Int64 { get; set; }

            public UInt16 UInt16 { get; set; }
            public UInt32 UInt32 { get; set; }
            public UInt64 UInt64 { get; set; }

            public Decimal Decimal { get; set; }
            public Boolean Boolean { get; set; }
            public Byte Byte { get; set; }

            public String String { get; set; }
            public Model OtherModel { get; set; }

            public IEnumerable<Int16> Int16List { get; set; }
            public IEnumerable<Int32> Int32List { get; set; }
            public IEnumerable<Int64> Int64List { get; set; }

            public IEnumerable<UInt16> UInt16List { get; set; }
            public IEnumerable<UInt32> UInt32List { get; set; }
            public IEnumerable<UInt64> UInt64List { get; set; }

            public IEnumerable<Decimal> DecimalList { get; set; }
            public IEnumerable<Boolean> BooleanList { get; set; }
            public IEnumerable<Byte> ByteList { get; set; }
            
            public IEnumerable<String> StringList { get; set; }
            public IEnumerable<Model> OtherModelList { get; set; }

        }
    }
}