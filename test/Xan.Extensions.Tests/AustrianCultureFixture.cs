using System.Globalization;

namespace Xan.Extensions.Tests;

public sealed class AustrianCultureFixture
    : IDisposable
{
    private static readonly CultureInfo _deAt = CultureInfo.GetCultureInfo("de-AT");

    private readonly CultureInfo _originalCultureInfo;

    public AustrianCultureFixture()
    {
        _originalCultureInfo = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = _deAt;
    }

    public void Dispose()
    {
        CultureInfo.CurrentCulture = _originalCultureInfo;
    }
}
