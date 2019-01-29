using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  class MKeyFrame
  {
    private float timeStamp;
    private Dictionary<String, MJointTransform> pose;

    /**
     * @param timeStamp
     *            - the time (in seconds) that this keyframe occurs during the
     *            animation.
     * @param jointKeyFrames
     *            - the local-space transforms for all the joints at this
     *            keyframe, indexed by the name of the joint that they should be
     *            applied to.
     */
    public MKeyFrame(float timeStamp, Dictionary<String, MJointTransform> jointKeyFrames)
    {
      this.timeStamp = timeStamp;
      this.pose = jointKeyFrames;
    }

    /**
     * @return The time in seconds of the keyframe in the animation.
     */
    protected float getTimeStamp()
    {
      return timeStamp;
    }

    /**
     * @return The desired bone-space transforms of all the joints at this
     *         keyframe, of the animation, indexed by the name of the joint that
     *         they correspond to. This basically represents the "pose" at this
     *         keyframe.
     */
    protected Dictionary<String, MJointTransform> getJointKeyFrames()
    {
      return pose;
    }
  }
}
