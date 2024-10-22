using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheblueMan003.NBT.Worlds
{
    public struct Vector2Int
    {
        public int X;
        public int Z;

        public Vector2Int(int x, int z)
        {
            X = x;
            Z = z;
        }

        public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new Vector2Int(a.X + b.X, a.Z + b.Z);

        public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new Vector2Int(a.X - b.X, a.Z - b.Z);

        public static Vector2Int operator *(Vector2Int a, Vector2Int b) => new Vector2Int(a.X * b.X, a.Z * b.Z);

        public static Vector2Int operator /(Vector2Int a, Vector2Int b) => new Vector2Int(a.X / b.X, a.Z / b.Z);

        public static Vector2Int operator %(Vector2Int a, Vector2Int b) => new Vector2Int(a.X % b.X, a.Z % b.Z);

        public static Vector2Int operator +(Vector2Int a, int b) => new Vector2Int(a.X + b, a.Z + b);

        public static Vector2Int operator -(Vector2Int a, int b) => new Vector2Int(a.X - b, a.Z - b);

        public static Vector2Int operator *(Vector2Int a, int b) => new Vector2Int(a.X * b, a.Z * b);

        public static Vector2Int operator /(Vector2Int a, int b) => new Vector2Int(a.X / b, a.Z / b);

        public static Vector2Int operator %(Vector2Int a, int b) => new Vector2Int(a.X % b, a.Z % b);

        public static Vector2Int operator +(int a, Vector2Int b) => new Vector2Int(a + b.X, a + b.Z);

        public static Vector2Int operator -(int a, Vector2Int b) => new Vector2Int(a - b.X, a - b.Z);

        public static Vector2Int operator *(int a, Vector2Int b) => new Vector2Int(a * b.X, a * b.Z);

        public static Vector2Int operator /(int a, Vector2Int b) => new Vector2Int(a / b.X, a / b.Z);

        public static Vector2Int operator %(int a, Vector2Int b) => new Vector2Int(a % b.X, a % b.Z);

        public static Vector2Int operator -(Vector2Int a) => new Vector2Int(-a.X, -a.Z);

        public static bool operator ==(Vector2Int a, Vector2Int b) => a.X == b.X && a.Z == b.Z;

        public static bool operator !=(Vector2Int a, Vector2Int b) => a.X != b.X || a.Z != b.Z;

        public static implicit operator Vector2Int((int x, int z) tuple) => new Vector2Int(tuple.x, tuple.z);

        public static implicit operator (int x, int z)(Vector2Int vector) => (vector.X, vector.Z);

        public override bool Equals(object obj) => obj is Vector2Int vector && vector == this;

        public override int GetHashCode() => X.GetHashCode() ^ Z.GetHashCode();

        public override string ToString() => $"({X}, {Z})";
    }
}
