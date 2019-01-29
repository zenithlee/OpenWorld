﻿using System;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using Chireiden.Meshes.Animations;
using Massive;

namespace Chireiden.Meshes
{
    /// <summary>
    /// A set of meshes that are a part of the same model, and therefore
    /// always share the same world-space transformations, and are rendered
    /// as one unit.
    /// </summary>
    public class MeshGroup : MeshContainer
    {
        List<TriMesh> meshes;
        bool castsShadows = true;

        public MeshGroup()
        {
            meshes = new List<TriMesh>();
        }

        public MeshGroup(List<TriMesh> ms)
        {
            meshes = new List<TriMesh>();
            this.meshes.AddRange(ms);
        }

        public void renderMeshes(MCamera camera, Matrix4 toWorldMatrix)
        {
            if (camera is Chireiden.Scenes.LightCamera)
            {
                if (castsShadows)
                {
                    ShaderProgram program = ShaderLibrary.ShadowMapShader;
                    Matrix4 viewMatrix = camera.getViewMatrix();
                    Matrix4 projectionMatrix = camera.getProjectionMatrix();

                    // Compute transformation matrices
                    Matrix4 modelView = Matrix4.Mult(toWorldMatrix, viewMatrix);
                    Matrix3 normalMatrix = Utils.normalMatrix(modelView);

                    program.use();

                    // set shader uniforms, incl. modelview and projection matrices
                    program.setUniformMatrix4("projectionMatrix", projectionMatrix);
                    program.setUniformMatrix4("modelViewMatrix", modelView);
                    program.setUniformMatrix4("viewMatrix", viewMatrix);
                    program.setUniformMatrix3("normalMatrix", normalMatrix);

                    program.setUniformInt1("shadowMapWidth", 1024);
                    program.setUniformInt1("shadowMapHeight", 1024);

                    foreach (TriMesh m in meshes)
                    {
                        m.renderMesh(camera, toWorldMatrix, program, 0);
                    }
                    program.unuse();
                }
            }

            else
            {
                ShaderProgram program = ShaderLibrary.BlenderShader;

                Matrix4 viewMatrix = camera.getViewMatrix();
                Matrix4 projectionMatrix = camera.getProjectionMatrix();

                // Compute transformation matrices
                Matrix4 modelView = Matrix4.Mult(toWorldMatrix, viewMatrix);
                Matrix3 normalMatrix = Utils.normalMatrix(modelView);

                program.use();

                // set shader uniforms, incl. modelview and projection matrices
                program.setUniformMatrix4("projectionMatrix", projectionMatrix);
                program.setUniformMatrix4("modelViewMatrix", modelView);
                program.setUniformMatrix4("viewMatrix", viewMatrix);
                program.setUniformMatrix3("normalMatrix", normalMatrix);

                //camera.setPointLightUniforms(program);

                foreach (TriMesh m in meshes)
                {
                    m.renderMesh(camera, toWorldMatrix, program, 0);
                }
                program.unuse();
            }

            
        }

        public void renderMeshes(MCamera c, Matrix4 m, Clip clip, double time)
        {
            renderMeshes(c, m);
        }

        public AnimationClip fetchAnimation(string s)
        {
            // Nothing to return.
            return null;
        }

        public bool hasAnimation(string s)
        {
            return false;
        }

        public void addMesh(TriMesh m)
        {
            meshes.Add(m);
        }

        public void removeMesh(TriMesh m)
        {
            meshes.Remove(m);
        }

        public List<TriMesh> getMeshes()
        {
            return meshes;
        }
    }
}
