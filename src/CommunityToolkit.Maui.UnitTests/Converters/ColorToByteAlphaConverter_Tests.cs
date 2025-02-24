﻿using CommunityToolkit.Maui.Converters;
using Xunit;

namespace CommunityToolkit.Maui.UnitTests.Converters;

public class ColorToByteAlphaConverter_Tests : BaseTest
{
	public static readonly IReadOnlyList<object[]> ValidInputData = new[]
	{
		new object[] { float.MinValue, (byte)0 },
		new object[] { -0.01f, (byte)0 },
		new object[] { -0f, (byte)0 },
		new object[] { 0f, (byte)0 },
		new object[] { 0.25f, (byte)64 },
		new object[] { 0.5f, (byte)128 },
		new object[] { 0.75f, (byte)191 },
		new object[] { 1f, (byte)255 },
		new object[] { 1.001f, (byte)255 },
		new object[] { float.MaxValue, (byte)255 },
	};

	[Theory]
	[MemberData(nameof(ValidInputData))]
	public void ColorToByteAlphaConverterValidInputTest(float alpha, byte expectedResult)
	{
		var color = new Color(0, 0, 0, alpha);
		var converter = new ColorToByteAlphaConverter();

		var resultConvertFrom = converter.ConvertFrom(color);
		var resultConvert = ((ICommunityToolkitValueConverter)converter).Convert(color, typeof(byte), null, null);

		Assert.Equal(expectedResult, resultConvertFrom);
		Assert.Equal(expectedResult, resultConvert);
	}

	[Fact]
	public void ColorToByteAlphaConverterNullInputTest()
	{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.Throws<ArgumentNullException>(() => new ColorToByteAlphaConverter().ConvertFrom(null));
		Assert.Throws<ArgumentNullException>(() => ((ICommunityToolkitValueConverter)new ColorToByteAlphaConverter()).Convert(null, typeof(byte), null, null));
		Assert.Throws<ArgumentNullException>(() => ((ICommunityToolkitValueConverter)new ColorToByteAlphaConverter()).Convert(new Color(), null, null, null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}
}