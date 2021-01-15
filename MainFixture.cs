namespace Scellecs.Collections.TestSuite {
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;
    using UnityEngine;
    using UnityEngine.TestTools;
    using System.Linq;

    public class MainFixture {
        #region IntHashSet
        
        [Test]
        [Category("IntHashSet")]
        public void IntHashSet_Simple_Ctor() {
            Assert.DoesNotThrow(() => {
                var ihs = new IntHashSet();
            });
        }
        
        [Test]
        [Category("IntHashSet")]
        [TestCase(30)]
        public void IntHashSet_Simple_Ctor_With_Capacity(int capacity) {
            var ihs = new IntHashSet(capacity);
            Assert.AreEqual(64, ihs.capacity);
        }
        #endregion

        #region IntHashSetExtensions
        [Test]
        [Category("IntHashSetExtensions")]
        public void IntHashSet_Add() {
            var ihs = new IntHashSet();
            
            ihs.Add(2);
            ihs.Add(4);
            ihs.Add(6);
            ihs.Add(8);

            Assert.AreEqual(4, ihs.length);
        }
        
        [Test]
        [TestCase()]
        [Category("IntHashSetExtensions")]
        public void IntHashSet_Remove() {
            var ihs = new IntHashSet(32);
            
            ihs.Add(2);
            ihs.Add(4);
            ihs.Add(6);
            ihs.Add(8);
            
            ihs.Remove(8);
            ihs.Remove(6);
            ihs.Remove(5); //IntHashSet does not contain '5', so it should have the same length.
            
            Assert.True(ihs.length == 2);
        }
        
        [Test] //TODO: Fix test
        [Category("IntHashSetExtensions")]
        public void IntHashSet_CopyTo() {
            var ihs = new IntHashSet(32);
            var arr = new int[32];

            Assert.DoesNotThrow(() => ihs.CopyTo(arr));
        }
        
        [Test]
        [Category("IntHashSetExtensions")]
        public void IntHashSet_Has() {
            var ihs = new IntHashSet(32);
            ihs.Add(2);
            
            Assert.True(ihs.Has(2));
        }
        
        [Test]
        [Category("IntHashSetExtensions")]
        public void IntHashSet_Clear() {
            var ihs = new IntHashSet(32);
            ihs.Add(2);
            ihs.Add(6);
            ihs.Add(4);
            ihs.Add(8);
            
            ihs.Clear();
            
            Assert.True(ihs.length == 0);
        }
        #endregion

        #region  IntHashMap
        [Test]
        [Category("IntHashMap")]
        public void IntHashMap_Simple_Ctor() {
            Assert.DoesNotThrow(() => {
                var ihm = new IntHashMap<int>();
            });
        }

        [Test]
        [Category("IntHashMap")]
        public void IntHashMap_Simple_Ctor_With_Capacity() {
            var ihm = new IntHashMap<int>(30);
            Assert.AreEqual(64, ihm.capacity);
        }
        #endregion

        #region IntHashMapExtensions
        [Test]
        [Category("IntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void IntHashMap_Add<T>(T value, int key) {
            var ihm = new IntHashMap<T>();
            int slotIndex;
            
            ihm.Add(key, value, out slotIndex);
            
            Assert.AreEqual(1, ihm.length); //Probably we need to check something like "slotIndex >= 1"
        }
        
        [Test]
        [Category("IntHashMapExtensions")]
        [TestCase(1, 2)] //TODO: Fix test
        public static void IntHashMap_Set<T>(T value, int key) {
            var ihm = new IntHashMap<T>();
            int slotIndex;
            
            ihm.Set(key, value, out slotIndex);
            
            Assert.AreEqual(value, ihm.data[slotIndex / 2]);
        }
        
        [Test]
        [Category("IntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void IntHashMap_Remove<T>(T value, int key) {
            var ihm = new IntHashMap<T>();
            int slotIndex;
            T   lastValue;
            
            ihm.Add(key, value, out slotIndex);
            ihm.Remove(key, out lastValue);
            
            Assert.True(value.Equals(lastValue) && ihm.length == 0);
        }
        
        [Test]
        [Category("IntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void IntHashMap_Has<T>(T value, int key) {
            var ihm = new IntHashMap<T>();
            int slotIndex;

            ihm.Add(key, value, out slotIndex);

            Assert.True(ihm.Has(key));
        }
        
        [Test]
        [Category("IntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void IntHashMap_TryGetValue<T>(T value, int key) {
            var ihm = new IntHashMap<T>();
            int slotIndex;
            T   tempValue;
            
            ihm.Add(key, value, out slotIndex);
            var result = ihm.TryGetValue(key, out tempValue);

            Assert.True(result && value.Equals(tempValue));
        }
        
        [Test]
        [Category("IntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void IntHashMap_GetValueByKey<T>(T value, int key) {
            var ihm = new IntHashMap<T>();
            int slotIndex;
            T   tempValue;
            
            ihm.Add(key, value, out slotIndex);
            tempValue = ihm.GetValueByKey(key);

            Assert.AreEqual(value, tempValue);
        }
        
        [Test]
        [Category("IntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void IntHashMap_GetValueByIndex<T>(T value, int key) {
            var ihm = new IntHashMap<T>();
            int slotIndex;
            T   tempValue;
            
            ihm.Add(key, value, out slotIndex);
            tempValue = ihm.GetValueByIndex(slotIndex);

            Assert.AreEqual(value, tempValue);
        }
        
        [Test]
        [Category("IntHashMapExtensions")]
        [TestCase(1, 2)] //TODO: Fix source
        public static void IntHashMap_GetKeyByIndex<T>(T value, int key) {
            var ihm = new IntHashMap<T>();
            int slotIndex, outKey;

            ihm.Add(key, value, out slotIndex);
            outKey = ihm.GetKeyByIndex(slotIndex);

            Assert.AreEqual(key, outKey);
        }
        
        [Test]
        [Category("IntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void IntHashMap_TryGetIndex<T>(T value, int key) {
            var ihm = new IntHashMap<T>();
            int slotIndex;
            int tempIndex;
            
            ihm.Add(key, value, out slotIndex);
            tempIndex = ihm.TryGetIndex(key);

            Assert.AreEqual(slotIndex, tempIndex);
        }
        
        [Test]
        [Category("IntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void IntHashMap_CopyTo<T>(T value, int key) {
            var ihm = new IntHashMap<T>();
            int slotIndex;
            var arr = new T[ihm.capacity];

            ihm.Add(key, value, out slotIndex);

            ihm.CopyTo(arr);

            Assert.AreEqual(ihm.data, arr);
        }
        
        [Test]
        [Category("IntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void IntHashMap_Clear<T>(T value, int key) {
            var ihm = new IntHashMap<T>();
            int slotIndex;

            ihm.Add(key, value, out slotIndex);
            ihm.Clear();

            Assert.AreEqual(0, ihm.length);
        }
        #endregion
        
        #region UnsafeIntHashMap

        [Test]
        [Category("UnsafeIntHashMap")]
        [TestCase(1)]
        public static void UnsafeIntHashMap_Ctor<T>(T value) where T : unmanaged {
            Assert.DoesNotThrow(() => {
                var uihm = new UnsafeIntHashMap<T>();
            });
        }
        
        [Test]
        [Category("UnsafeIntHashMap")]
        [TestCase(1, 30)]
        public static void UnsafeIntHashMap_Ctor_With_Capacity<T>(T value, int capacity) where T : unmanaged {
            var uihm = new UnsafeIntHashMap<T>(capacity);
            
            Assert.AreEqual(64, uihm.capacity);
        }
        #endregion

        #region UnsafeIntHashMapExtensions

        [Test]
        [Category("UnsafeIntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void UnsafeIntHashMap_Add<T>(int key, T value) where T : unmanaged {
            int outIndex;
            
            var uihm = new UnsafeIntHashMap<T>();
            uihm.Add(key, value, out outIndex);
            
            Assert.AreEqual(1, uihm.length);
        }
        
        [Test]
        [Category("UnsafeIntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void UnsafeIntHashMap_Remove<T>(int key, T value) where T : unmanaged {
            int outIndex;
            T   lastValue;
            
            var uihm = new UnsafeIntHashMap<T>();
            uihm.Add(key, value, out outIndex);
            uihm.Remove(key, out lastValue);
            
            Assert.True(value.Equals(lastValue) && uihm.length == 0);
        }
        
        [Test]
        [Category("UnsafeIntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void UnsafeIntHashMap_TryGetValue<T>(int key, T value) where T : unmanaged {
            int outIndex;
            T   lastValue;
            
            var uihm = new UnsafeIntHashMap<T>();
            uihm.Add(key, value, out outIndex);
            uihm.TryGetValue(key, out lastValue);
            
            Assert.AreEqual(value, lastValue);
        }
        
        [Test]
        [Category("UnsafeIntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void UnsafeIntHashMap_GetValueByKey<T>(int key, T value) where T : unmanaged {
            int outIndex;
            T   outValue;
            
            var uihm = new UnsafeIntHashMap<T>();
            uihm.Add(key, value, out outIndex);
            outValue = uihm.GetValueByKey(key);
            
            Assert.AreEqual(value, outValue);
        }
        
        [Test]
        [Category("UnsafeIntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void UnsafeIntHashMap_GetValueByIndex<T>(int key, T value) where T : unmanaged {
            int outIndex;
            T   outValue;
            
            var uihm = new UnsafeIntHashMap<T>();
            uihm.Add(key, value, out outIndex);
            outValue = uihm.GetValueByIndex(outIndex);
            
            Assert.AreEqual(value, outValue);
        }
        
        [Test]
        [Category("UnsafeIntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void UnsafeIntHashMap_GetKeyByIndex<T>(int key, T value) where T : unmanaged {
            int outIndex, outKey;

            var uihm = new UnsafeIntHashMap<T>();
            uihm.Add(key, value, out outIndex);
            outKey = uihm.GetKeyByIndex(outIndex);
            
            Assert.AreEqual(key, outKey);
        }
        
        [Test]
        [Category("UnsafeIntHashMapExtensions")]
        [TestCase(1, 2)]
        public static void UnsafeIntHashMap_TryGetIndex<T>(int key, T value) where T : unmanaged {
            int outIndex, newIndex;

            var uihm = new UnsafeIntHashMap<T>();
            uihm.Add(key, value, out outIndex);
            newIndex = uihm.TryGetIndex(key);
            
            Assert.AreEqual(outIndex, newIndex);
        }
        
        [Test]
        [Category("UnsafeIntHashMapExtensions")]
        [TestCase(1, 2, 1, 2)]
        public static void UnsafeIntHashMap_Clear<T>(int key1, int key2, T value1, T value2) where T : unmanaged {
            int outIndex1, outIndex2;

            var uihm = new UnsafeIntHashMap<T>();
            uihm.Add(key1, value1, out outIndex1);
            uihm.Add(key2, value2, out outIndex2);
            uihm.Clear();

            Assert.AreEqual(0, uihm.length);
        }
        #endregion
    }
}