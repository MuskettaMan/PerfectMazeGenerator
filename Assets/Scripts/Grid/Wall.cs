public class Wall {

    public bool enabled;

    public Cell first;
    public Cell second;

    public Wall(bool enabled, Cell first, Cell second) {
        this.enabled = enabled;
        this.first = first;
        this.second = second;
    }

}
