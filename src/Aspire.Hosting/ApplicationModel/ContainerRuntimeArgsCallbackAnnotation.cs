// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;

namespace Aspire.Hosting.ApplicationModel;

/// <summary>
/// Represents an additional argument to pass to the container runtime run command.
/// </summary>
[DebuggerDisplay("Type = {GetType().Name,nq}")]
public sealed class ContainerRuntimeArgsCallbackAnnotation : IResourceAnnotation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ContainerRuntimeArgsCallbackAnnotation"/> class with the specified callback action.
    /// </summary>
    /// <param name="callback"></param>
    public ContainerRuntimeArgsCallbackAnnotation(Func<ContainerRuntimeArgsCallbackContext, Task> callback)
    {
        ArgumentNullException.ThrowIfNull(callback);

        Callback = callback;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ContainerRuntimeArgsCallbackAnnotation"/> class with the specified callback action.
    /// </summary>
    /// <param name="callback">The callback action to be executed.</param>
    public ContainerRuntimeArgsCallbackAnnotation(Action<IList<object>> callback)
    {
        ArgumentNullException.ThrowIfNull(callback);

        Callback = (c) =>
        {
            callback(c.Args);
            return Task.CompletedTask;
        };
    }

    /// <summary>
    /// Gets the callback action to be executed when the executable arguments are parsed.
    /// </summary>
    public Func<ContainerRuntimeArgsCallbackContext, Task> Callback { get; }
}

/// <summary>
/// Represents a callback context for the list of command-line arguments to be passed to the container runtime run command.
/// </summary>
/// <param name="args">The list of command-line arguments.</param>
/// <param name="cancellationToken">The cancellation token associated with this execution.</param>
public sealed class ContainerRuntimeArgsCallbackContext(IList<object> args, CancellationToken cancellationToken = default)
{
    /// <summary>
    /// Gets the list of command-line arguments.
    /// </summary>
    public IList<object> Args { get; } = args ?? throw new ArgumentNullException(nameof(args));

    /// <summary>
    /// Gets the cancellation token associated with the callback context.
    /// </summary>
    public CancellationToken CancellationToken { get; } = cancellationToken;
}