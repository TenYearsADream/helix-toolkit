﻿/*
The MIT License (MIT)
Copyright (c) 2018 Helix Toolkit contributors
*/
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using System;

#if !NETFX_CORE
namespace HelixToolkit.Wpf.SharpDX
#else
namespace HelixToolkit.UWP
#endif
{
    using Render;
    using System.Collections.Generic;
    using Utilities;
    public interface IAttachableBufferModel : IGUID, IDisposable
    {
        /// <summary>
        /// Occurs when [on invalidate renderer].
        /// </summary>
        event EventHandler<EventArgs> OnInvalidateRender;
        /// <summary>
        /// Gets or sets the topology.
        /// </summary>
        /// <value>
        /// The topology.
        /// </value>
        PrimitiveTopology Topology { set; get; }

        /// <summary>
        /// Gets the vertex buffer.
        /// </summary>
        /// <value>
        /// The vertex buffer.
        /// </value>
        IElementsBufferProxy[] VertexBuffer { get; }
        /// <summary>
        /// Gets the size of the vertex structure.
        /// </summary>
        /// <value>
        /// The size of the vertex structure.
        /// </value>
        IEnumerable<int> VertexStructSize { get; }
        /// <summary>
        /// Gets the index buffer.
        /// </summary>
        /// <value>
        /// The index buffer.
        /// </value>
        IElementsBufferProxy IndexBuffer { get; }
        /// <summary>
        /// Attaches the buffers.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="vertexLayout">The vertex layout.</param>
        /// <param name="vertexBufferStartSlot">The vertex buffer slot. It will be changed to next available slot after binding.</param>
        /// <param name="deviceResources"></param>
        /// <returns></returns>
        bool AttachBuffers(DeviceContextProxy context, InputLayout vertexLayout, ref int vertexBufferStartSlot, IDeviceResources deviceResources);
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IGeometryBufferModel : IAttachableBufferModel
    {
        /// <summary>
        /// Gets or sets the geometry.
        /// </summary>
        /// <value>
        /// The geometry.
        /// </value>
        Geometry3D Geometry { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public interface IBillboardBufferModel : IDisposable
    {
        /// <summary>
        /// Gets the texture view.
        /// </summary>
        /// <value>
        /// The texture view.
        /// </value>
        ShaderResourceViewProxy TextureView { get; }
        /// <summary>
        /// Gets the billboard type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        BillboardType Type { get; }
    }
}