using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
  class MAnimation
  {
    private float length;//in seconds
    private MKeyFrame[] keyFrames;

	/**
	 * @param lengthInSeconds
	 *            - the total length of the animation in seconds.
	 * @param frames
	 *            - all the keyframes for the animation, ordered by time of
	 *            appearance in the animation.
	 */
	public MAnimation(float lengthInSeconds, MKeyFrame[] frames)
    {
      this.keyFrames = frames;
      this.length = lengthInSeconds;
    }

    /**
     * @return The length of the animation in seconds.
     */
    public float getLength()
    {
      return length;
    }

    /**
     * @return An array of the animation's keyframes. The array is ordered based
     *         on the order of the keyframes in the animation (first keyframe of
     *         the animation in array position 0).
     */
    public MKeyFrame[] getKeyFrames()
    {
      return keyFrames;
    }
  }
}
