using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
// ReSharper disable StringLiteralTypo

namespace Grandpa3D.Scripts
{
    public class BackupFrameBufferPass : CustomPass
    {
        [Header(" Blur Texture Output")]
        [SerializeField] private RenderTexture _outputRenderTexture;

        protected override bool executeInSceneView => true;
        
        protected override void Execute(CustomPassContext ctx)
        {
            if(_outputRenderTexture is not null)
            {
                var scale = RTHandles.rtHandleProperties.rtHandleScale;
                ctx.cmd.Blit(ctx.customColorBuffer.Value, _outputRenderTexture,new Vector2(scale.x, scale.y), Vector2.zero, 0, 0);
            }
        }
        
        protected override void Cleanup()
        {
            base.Cleanup();
        }
    }
}