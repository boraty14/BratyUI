namespace BratyUI
{
    public static class ReferenceConstants
    {
        public static float ReferenceX { get; private set; } = 900f;
        public static float ReferenceY { get; private set; } = 2000f;
        public static float ReferenceRatio => ReferenceX / ReferenceY;

        public static float GetRatioX(float width) => width / ReferenceX;
        public static float GetRatioY(float height) => height / ReferenceY;
    }
}
