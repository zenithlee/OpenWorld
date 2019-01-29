using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  class MJointTransform
  {
    // remember, this position and rotation are relative to the parent bone!
    private Vector3 position;
    private Quaternion rotation;

    /**
     * 
     * @param position
     *            - the position of the joint relative to the parent joint
     *            (bone-space) at a certain keyframe. For example, if this joint
     *            is at (5, 12, 0) in the model's coordinate system, and the
     *            parent of this joint is at (2, 8, 0), then the position of
     *            this joint relative to the parent is (3, 4, 0).
     * @param rotation
     *            - the rotation of the joint relative to the parent joint
     *            (bone-space) at a certain keyframe.
     */
    public MJointTransform(Vector3 position, Quaternion rotation)
    {
      this.position = position;
      this.rotation = rotation;
    }

    /**
     * In this method the bone-space transform matrix is constructed by
     * translating an identity matrix using the position variable and then
     * applying the rotation. The rotation is applied by first converting the
     * quaternion into a rotation matrix, which is then multiplied with the
     * transform matrix.
     * 
     * @return This bone-space joint transform as a matrix. The exact same
     *         transform as represented by the position and rotation in this
     *         instance, just in matrix form.
     */
    protected Matrix4 getLocalTransform()
    {
      Matrix4 matrix = Matrix4.CreateTranslation(position);
      Matrix4 rotmatrix = Matrix4.CreateFromQuaternion(rotation);
      Matrix4.Mult(ref matrix, ref rotmatrix, out matrix);
      return matrix;
    }

    /**
     * Interpolates between two transforms based on the progression value. The
     * result is a new transform which is part way between the two original
     * transforms. The translation can simply be linearly interpolated, but the
     * rotation interpolation is slightly more complex, using a method called
     * "SLERP" to spherically-linearly interpolate between 2 quaternions
     * (rotations). This gives a much much better result than trying to linearly
     * interpolate between Euler rotations.
     * 
     * @param frameA
     *            - the previous transform
     * @param frameB
     *            - the next transform
     * @param progression
     *            - a number between 0 and 1 indicating how far between the two
     *            transforms to interpolate. A progression value of 0 would
     *            return a transform equal to "frameA", a value of 1 would
     *            return a transform equal to "frameB". Everything else gives a
     *            transform somewhere in-between the two.
     * @return
     */
    protected static MJointTransform interpolate(MJointTransform frameA, MJointTransform frameB, float progression)
    {
      Vector3 pos = interpolate(frameA.position, frameB.position, progression);
      Quaternion rot = Quaternion.Slerp(frameA.rotation, frameB.rotation, progression);
      return new MJointTransform(pos, rot);
    }

    /**
     * Linearly interpolates between two translations based on a "progression"
     * value.
     * 
     * @param start
     *            - the start translation.
     * @param end
     *            - the end translation.
     * @param progression
     *            - a value between 0 and 1 indicating how far to interpolate
     *            between the two translations.
     * @return
     */
    private static Vector3 interpolate(Vector3 start, Vector3 end, float progression)
    {
      float x = start.X + (end.X - start.X) * progression;
      float y = start.Y + (end.Y - start.Y) * progression;
      float z = start.Z + (end.Z - start.Z) * progression;
      return new Vector3(x, y, z);
    }
  }
}
