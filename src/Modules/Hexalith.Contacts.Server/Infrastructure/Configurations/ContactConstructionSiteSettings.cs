﻿// ***********************************************************************
// Assembly         : Hexalith.Infrastructure.DaprRuntime.Contact
// Author           : Jérôme Piquot
// Created          : 02-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 09-02-2023
// ***********************************************************************
// <copyright file="EnvironmentDatabaseSettings.cs" company="Hexalith SAS Paris France">
//     Copyright (c) Hexalith SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Contacts.Server.Infrastructure.Configurations;

using Hexalith.Application.Configurations;
using Hexalith.Contact.Domain;
using Hexalith.Extensions.Configuration;

/// <summary>
/// Class InvoiceSettings.
/// Implements the <see cref="ISettings" />.
/// </summary>
/// <seealso cref="ISettings" />
public class ContactSettings : ISettings
{
    /// <summary>
    /// Gets or sets the command processor.
    /// </summary>
    /// <value>The command processor.</value>
    public CommandProcessorSettings? CommandProcessor { get; set; }

    /// <summary>
    /// The configuration section name of the settings.
    /// </summary>
    /// <returns>The name.</returns>
    public static string ConfigurationName() => ContactDomainHelper.ContactAggregateName;
}