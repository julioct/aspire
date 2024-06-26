// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;

namespace Aspire.Azure.Security.KeyVault.Tests;

public class ConfigurationTests
{
    [Fact]
    public void VaultUriIsNullByDefault()
        => Assert.Null(new AzureSecurityKeyVaultSettings().VaultUri);

    [Fact]
    public void HealthCheckIsEnabledByDefault()
        => Assert.False(new AzureSecurityKeyVaultSettings().DisableHealthChecks);

    [Fact]
    public void TracingIsEnabledByDefault()
        => Assert.False(new AzureSecurityKeyVaultSettings().DisableTracing);
}
