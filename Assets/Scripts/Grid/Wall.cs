public class Wall {

    /// <summary>
    /// Is the wall active or not
    /// </summary>
    public bool enabled;

    /// <summary>
    /// The first cell the wall is seperating. This is either bottom or left
    /// </summary>
    public Cell first;

    /// <summary>
    /// The second cell the wall is seperating. This is eiter top or right
    /// </summary>
    public Cell second;

    /// <summary>
    /// Set members
    /// </summary>
    /// <param name="enabled">Is the wall enabled or not</param>
    /// <param name="first">The first cell the wall is seperating. This is either bottom or left</param>
    /// <param name="second">The second cell the wall is seperating. This is eiter top or right</param>
    public Wall(bool enabled, Cell first, Cell second) {
        this.enabled = enabled;
        this.first = first;
        this.second = second;
    }

}
