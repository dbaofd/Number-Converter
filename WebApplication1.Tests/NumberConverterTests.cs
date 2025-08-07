using Xunit;
using NumberConverter;

namespace WebApplication1.Tests
{
    public class NumberConverterTests
    {
        private readonly NumberConverter.NumberConverter _converter;

        public NumberConverterTests()
        {
            _converter = new NumberConverter.NumberConverter();
        }

        #region Zero Values Tests

        [Fact]
        public void ConvertToCurrency_ZeroValues_Test1()
        {
            var result = _converter.ConvertToCurrency("0.00");
            Assert.Equal("ZERO DOLLAR", result);
        }

        [Fact]
        public void ConvertToCurrency_ZeroValues_Test2()
        {
            var result = _converter.ConvertToCurrency("0");
            Assert.Equal("ZERO DOLLAR", result);
        }

        [Fact]
        public void ConvertToCurrency_ZeroValues_Test3()
        {
            var result = _converter.ConvertToCurrency("0.0");
            Assert.Equal("ZERO DOLLAR", result);
        }

        [Fact]
        public void ConvertToCurrency_ZeroValues_Test4()
        {
            var result = _converter.ConvertToCurrency("0.003");
            Assert.Equal("ZERO DOLLAR", result);
        }

        #endregion

        #region Single Units Tests

        [Fact]
        public void ConvertToCurrency_SingleUnits_Test1()
        {
            var result = _converter.ConvertToCurrency("1.00");
            Assert.Equal("ONE DOLLAR", result);
        }

        [Fact]
        public void ConvertToCurrency_SingleUnits_Test2()
        {
            var result = _converter.ConvertToCurrency("0.01");
            Assert.Equal("ONE CENT", result);
        }

        [Fact]
        public void ConvertToCurrency_SingleUnits_Test3()
        {
            var result = _converter.ConvertToCurrency("1.01");
            Assert.Equal("ONE DOLLAR AND ONE CENT", result);
        }

        #endregion

        #region Basic Numbers Tests

        [Fact]
        public void ConvertToCurrency_BasicNumbers_Test1()
        {
            var result = _converter.ConvertToCurrency("2.00");
            Assert.Equal("TWO DOLLARS", result);
        }

        [Fact]
        public void ConvertToCurrency_BasicNumbers_Test2()
        {
            var result = _converter.ConvertToCurrency("0.99");
            Assert.Equal("NINETY-NINE CENTS", result);
        }

        [Fact]
        public void ConvertToCurrency_BasicNumbers_Test3()
        {
            var result = _converter.ConvertToCurrency("123.45");
            Assert.Equal("ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS", result);
        }

        [Fact]
        public void ConvertToCurrency_BasicNumbers_Test4()
        {
            var result = _converter.ConvertToCurrency("14568.8489");
            Assert.Equal("FOURTEEN THOUSAND FIVE HUNDRED AND SIXTY-EIGHT DOLLARS AND EIGHTY-FIVE CENTS", result);
        }

        [Fact]
        public void ConvertToCurrency_BasicNumbers_Test5()
        {
            var result = _converter.ConvertToCurrency("478728.9873");
            Assert.Equal("FOUR HUNDRED AND SEVENTY-EIGHT THOUSAND SEVEN HUNDRED AND TWENTY-EIGHT DOLLARS AND NINETY-NINE CENTS", result);
        }

        [Fact]
        public void ConvertToCurrency_BasicNumbers_Test6()
        {
            var result = _converter.ConvertToCurrency("12345.78");
            Assert.Equal("TWELVE THOUSAND THREE HUNDRED AND FORTY-FIVE DOLLARS AND SEVENTY-EIGHT CENTS", result);
        }

        #endregion

        #region Rounding Cases Tests

        [Fact]
        public void ConvertToCurrency_RoundingCases_Test1()
        {
            var result = _converter.ConvertToCurrency("0.995");
            Assert.Equal("ONE DOLLAR", result);
        }

        [Fact]
        public void ConvertToCurrency_RoundingCases_Test2()
        {
            var result = _converter.ConvertToCurrency("0.994");
            Assert.Equal("NINETY-NINE CENTS", result);
        }

        [Fact]
        public void ConvertToCurrency_RoundingCases_Test3()
        {
            var result = _converter.ConvertToCurrency("1.996");
            Assert.Equal("TWO DOLLARS", result);
        }

        #endregion

        #region Large Numbers Tests

        [Fact]
        public void ConvertToCurrency_LargeNumbers_Test1()
        {
            var result = _converter.ConvertToCurrency("1000000.00");
            Assert.Equal("ONE MILLION DOLLARS", result);
        }

        [Fact]
        public void ConvertToCurrency_LargeNumbers_Test2()
        {
            var result = _converter.ConvertToCurrency("1000000000.00");
            Assert.Equal("ONE BILLION DOLLARS", result);
        }

        [Fact]
        public void ConvertToCurrency_LargeNumbers_Test3()
        {
            var result = _converter.ConvertToCurrency("999999999999999999.99");
            Assert.Equal("NINE HUNDRED AND NINETY-NINE QUADRILLION NINE HUNDRED AND NINETY-NINE TRILLION NINE HUNDRED AND NINETY-NINE BILLION NINE HUNDRED AND NINETY-NINE MILLION NINE HUNDRED AND NINETY-NINE THOUSAND NINE HUNDRED AND NINETY-NINE DOLLARS AND NINETY-NINE CENTS", result);
        }

        [Fact]
        public void ConvertToCurrency_LargeNumbers_Test4()
        {
            var result = _converter.ConvertToCurrency("89489894869.895");
            Assert.Equal("EIGHTY-NINE BILLION FOUR HUNDRED AND EIGHTY-NINE MILLION EIGHT HUNDRED AND NINETY-FOUR THOUSAND EIGHT HUNDRED AND SIXTY-NINE DOLLARS AND NINETY CENTS", result);
        }

        [Fact]
        public void ConvertToCurrency_LargeNumbers_Test5()
        {
            var result = _converter.ConvertToCurrency("4673875837878.84938");
            Assert.Equal("FOUR TRILLION SIX HUNDRED AND SEVENTY-THREE BILLION EIGHT HUNDRED AND SEVENTY-FIVE MILLION EIGHT HUNDRED AND THIRTY-SEVEN THOUSAND EIGHT HUNDRED AND SEVENTY-EIGHT DOLLARS AND EIGHTY-FIVE CENTS", result);
        }

        #endregion

        #region Edge Cases Tests

        [Fact]
        public void ConvertToCurrency_EdgeCases_Test1()
        {
            var result = _converter.ConvertToCurrency("9999999999999999999.99");
            Assert.Equal("Number too large, maximum number supported is 999,999,999,999,999,999.99", result);
        }

        [Fact]
        public void ConvertToCurrency_EdgeCases_Test2()
        {
            var result = _converter.ConvertToCurrency("50");
            Assert.Equal("FIFTY DOLLARS", result);
        }

        [Fact]
        public void ConvertToCurrency_EdgeCases_Test3()
        {
            var result = _converter.ConvertToCurrency("5.");
            Assert.Equal("FIVE DOLLARS", result);
        }
        [Fact]
        public void ConvertToCurrency_EdgeCases_Test4()
        {
            var result = _converter.ConvertToCurrency("999999999999999999.996");
            Assert.Equal("Number too large, maximum number supported is 999,999,999,999,999,999.99", result);
        }

        #endregion

        #region Format Variations Tests

        [Fact]
        public void ConvertToCurrency_FormatVariations_Test1()
        {
            var result = _converter.ConvertToCurrency("000123.45");
            Assert.Equal("ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS", result);
        }

        [Fact]
        public void ConvertToCurrency_FormatVariations_Test2()
        {
            var result = _converter.ConvertToCurrency("1.004");
            Assert.Equal("ONE DOLLAR", result);
        }

        [Fact]
        public void ConvertToCurrency_FormatVariations_Test3()
        {
            var result = _converter.ConvertToCurrency("12.5");
            Assert.Equal("TWELVE DOLLARS AND FIFTY CENTS", result);
        }

        #endregion
    }
}