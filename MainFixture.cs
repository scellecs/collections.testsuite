namespace Scellecs.Collections.TestSuite {
    using NUnit.Framework;
    using Collections;

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
        public void IntHashMap_Add<T>(T value, int key) {
            var ihm = new IntHashMap<T>();
            int slotIndex;
            
            ihm.Add(key, value, out slotIndex);
            
            Assert.AreEqual(1, ihm.length); //Probably we need to check something like "slotIndex >= 1"
        }
        
        [Test]
        [Category("IntHashMapExtensions")]
        [TestCase(1, 2)] //TODO: Fix test
        public void IntHashMap_Set<T>(T value, int key) {
            var ihm = new IntHashMap<T>();
            int slotIndex;
            
            ihm.Set(key, value, out slotIndex);
            
            Assert.AreEqual(value, ihm.data[slotIndex / 2]);
        }
        
        [Test]
        [Category("IntHashMapExtensions")]
        [TestCase(1, 2)]
        public void IntHashMap_Remove<T>(T value, int key) {
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
        public void IntHashMap_Has<T>(T value, int key) {
            var ihm = new IntHashMap<T>();
            int slotIndex;

            ihm.Add(key, value, out slotIndex);

            Assert.True(ihm.Has(key));
        }
        
        [Test]
        [Category("IntHashMapExtensions")]
        [TestCase(1, 2)]
        public void IntHashMap_TryGetValue<T>(T value, int key) {
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
        public void IntHashMap_GetValueByKey<T>(T value, int key) {
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
        public void IntHashMap_GetValueByIndex<T>(T value, int key) {
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
        public void IntHashMap_GetKeyByIndex<T>(T value, int key) {
            var ihm = new IntHashMap<T>();
            int slotIndex, outKey;

            ihm.Add(key, value, out slotIndex);
            outKey = ihm.GetKeyByIndex(slotIndex);

            Assert.AreEqual(key, outKey);
        }
        
        [Test]
        [Category("IntHashMapExtensions")]
        [TestCase(1, 2)]
        public void IntHashMap_TryGetIndex<T>(T value, int key) {
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
        public void IntHashMap_CopyTo<T>(T value, int key) {
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
        public void IntHashMap_Clear<T>(T value, int key) {
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
        public void UnsafeIntHashMap_Ctor<T>(T value) where T : unmanaged {
            Assert.DoesNotThrow(() => {
                var uihm = new UnsafeIntHashMap<T>();
            });
        }
        
        [Test]
        [Category("UnsafeIntHashMap")]
        [TestCase(1, 30)]
        public void UnsafeIntHashMap_Ctor_With_Capacity<T>(T value, int capacity) where T : unmanaged {
            var uihm = new UnsafeIntHashMap<T>(capacity);
            
            Assert.AreEqual(64, uihm.capacity);
        }
        #endregion

        #region UnsafeIntHashMapExtensions

        [Test]
        [Category("UnsafeIntHashMapExtensions")]
        [TestCase(1, 2)]
        public void UnsafeIntHashMap_Add<T>(int key, T value) where T : unmanaged {
            int outIndex;
            
            var uihm = new UnsafeIntHashMap<T>();
            uihm.Add(key, value, out outIndex);
            
            Assert.AreEqual(1, uihm.length);
        }
        
        [Test]
        [Category("UnsafeIntHashMapExtensions")]
        [TestCase(1, 2)]
        public void UnsafeIntHashMap_Remove<T>(int key, T value) where T : unmanaged {
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
        public void UnsafeIntHashMap_TryGetValue<T>(int key, T value) where T : unmanaged {
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
        public void UnsafeIntHashMap_GetValueByKey<T>(int key, T value) where T : unmanaged {
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
        public void UnsafeIntHashMap_GetValueByIndex<T>(int key, T value) where T : unmanaged {
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
        public void UnsafeIntHashMap_GetKeyByIndex<T>(int key, T value) where T : unmanaged {
            int outIndex, outKey;

            var uihm = new UnsafeIntHashMap<T>();
            uihm.Add(key, value, out outIndex);
            outKey = uihm.GetKeyByIndex(outIndex);
            
            Assert.AreEqual(key, outKey);
        }
        
        [Test]
        [Category("UnsafeIntHashMapExtensions")]
        [TestCase(1, 2)]
        public void UnsafeIntHashMap_TryGetIndex<T>(int key, T value) where T : unmanaged {
            int outIndex, newIndex;

            var uihm = new UnsafeIntHashMap<T>();
            uihm.Add(key, value, out outIndex);
            newIndex = uihm.TryGetIndex(key);
            
            Assert.AreEqual(outIndex, newIndex);
        }
        
        [Test]
        [Category("UnsafeIntHashMapExtensions")]
        [TestCase(1, 2, 1, 2)]
        public void UnsafeIntHashMap_Clear<T>(int key1, int key2, T value1, T value2) where T : unmanaged {
            int outIndex1, outIndex2;

            var uihm = new UnsafeIntHashMap<T>();
            uihm.Add(key1, value1, out outIndex1);
            uihm.Add(key2, value2, out outIndex2);
            uihm.Clear();

            Assert.AreEqual(0, uihm.length);
        }
        #endregion

        #region IntStack
        [Test]
        [Category("IntStack")]
        public void IntStack_Ctor() {
            Assert.DoesNotThrow(() => {
                var stack = new IntStack();
            });
        }

        #endregion

        #region IntStackExtensions

        [Test]
        [Category("IntStackExtensions")]
        [TestCase(3,4)]
        public void IntStack_Push(int value1, int value2) {
            var stack = new IntStack();
            stack.Push(value1);
            stack.Push(value2);
            
            Assert.AreEqual(2, stack.length);
        }
        
        [Test]
        [Category("IntStackExtensions")]
        [TestCase(3,4)]
        public void IntStack_Pop(int value1, int value2) {
            var stack = new IntStack();
            stack.Push(value1);
            stack.Push(value2);

            var actual = stack.Pop();
            
            Assert.AreEqual(4, actual);
        }
        
        [Test]
        [Category("IntStackExtensions")]
        [TestCase(3,4)]
        public void IntStack_Clear(int value1, int value2) {
            var stack = new IntStack();
            stack.Push(value1);
            stack.Push(value2);
            stack.Clear();

            Assert.AreEqual(0, stack.length);
        }

        #endregion

        #region FastList
        [Test]
        [Category("FastList")]
        [TestCase(typeof(int))]
        public void FastList_Ctor<T>(T type) {
            Assert.DoesNotThrow(() => {
                var fl = new FastList<T>();
            });
        }
        
        [Test]
        [Category("FastList")]
        [TestCase(typeof(int), 30)]
        public void FastList_Ctor_With_Capacity<T>(T type, int capacity) {
            var fl = new FastList<T>(capacity);
            
            Assert.AreEqual(63, fl.capacity);
        }
        
        [Test]
        [Category("FastList")]
        [TestCase(typeof(int), 30)]
        public void FastList_Ctor_With_Other<T>(T type, int capacity) {
            var fl1 = new FastList<T>(capacity);
            var fl2 = new FastList<T>(fl1);
            
            Assert.AreEqual(fl1.capacity, fl2.capacity);
        }
        
        #endregion
        
        #region FastListExtensions
        [Test]
        [Category("FastListExtensions")]
        [TestCase(1)]
        public void FastList_Add<T>(T value) {
            var fl1 = new FastList<T>();
            fl1.Add();

            Assert.AreEqual(1, fl1.length);
        }
        
        [Test]
        [Category("FastListExtensions")]
        [TestCase(1)]
        public void FastList_Add_With_Value<T>(T value) {
            var fl1 = new FastList<T>();
            fl1.Add(value);

            Assert.AreEqual(1, fl1.length);
        }
        
        [Test]
        [Category("FastListExtensions")]
        [TestCase(1,2)]
        public void FastList_Add_List_Range<T>(T value1, T value2) {
            var fl1 = new FastList<T>();
            
            var fl2 = new FastList<T>();
            fl1.Add(value1);
            fl1.Add(value2);
            
            fl2.AddListRange(fl1);

            Assert.AreEqual(2, fl2.length);
        }
        
        [Test]
        [Category("FastListExtensions")]
        [TestCase(1,2)]
        public void FastList_Swap<T>(T value1, T value2) {
            var fl1 = new FastList<T>(); //TODO: Check source logic (is it a swap?)
            
            fl1.Add(value1);
            fl1.Add(value2);
            fl1.Swap(0, 1);
            
            Assert.True(value1.Equals(fl1.data[1]) && value2.Equals(fl1.data[0]), fl1.data[0].ToString());
        }
        
        [Test]
        [Category("FastListExtensions")]
        [TestCase(1,2)]
        public void FastList_Index_Of<T>(T value1, T value2) {
            var fl1 = new FastList<T>();
            
            fl1.Add(value1);
            var index = fl1.IndexOf(value1);
            
            Assert.AreEqual(0,index);
        }
        
        [Test]
        [Category("FastListExtensions")]
        [TestCase(1,2)]
        public void FastList_Remove<T>(T value1, T value2) {
            var fl1 = new FastList<T>();
            
            fl1.Add(value1);
            fl1.Remove(value1);

            Assert.AreEqual(0, fl1.length);
        }
        
        [Test]
        [Category("FastListExtensions")]
        [TestCase(1,2)]
        public void FastList_Remove_Swap<T>(T value1, T value2) {
            var fl1 = new FastList<T>(); //TODO: check if it's true (Assert logic)
            
            fl1.Add(value1);
            fl1.Add(value2);
            fl1.RemoveSwap(value1, out var resultSwap);

            Assert.AreEqual(1, resultSwap.oldIndex);
        }
        
        [Test]
        [Category("FastListExtensions")]
        [TestCase(1,2)]
        public void FastList_Remove_At<T>(T value1, T value2) {
            var fl1 = new FastList<T>();
            
            fl1.Add(value1);
            fl1.Add(value2);
            fl1.RemoveAt(1);
            
            Assert.AreEqual(0, fl1.data[1]);
        }
        
        [Test]
        [Category("FastListExtensions")]
        [TestCase(1,2)]
        public void FastList_Clear<T>(T value1, T value2) {
            var fl1 = new FastList<T>();
            
            fl1.Add(value1);
            fl1.Add(value2);
            fl1.Clear();
            
            Assert.AreEqual(0, fl1.length);
        }
        
        [Test]
        [Category("FastListExtensions")]
        [TestCase(2,1)]
        public void FastList_Sort<T>(T value1, T value2) {
            var fl1 = new FastList<T>();
            
            fl1.Add(value1);
            fl1.Add(value2);
            fl1.Sort();

            Assert.AreEqual(1, fl1.data[0]);
        }
        
        [Test]
        [Category("FastListExtensions")]
        [TestCase(2,1)]
        public void FastList_Sort_By_Index_And_Len<T>(T value1, T value2) {
            var fl1 = new FastList<T>();
            
            fl1.Add(value1);
            fl1.Add(value2);
            fl1.Sort(0, 2);
            
            Assert.AreEqual(1, fl1.data[0]);
        }
        
        [Test]
        [Category("FastListExtensions")]
        [TestCase(1,2)]
        public void FastList_ToArray<T>(T value1, T value2) {
            var fl1 = new FastList<T>(); //TODO: fix
            
            fl1.Add(value1);
            fl1.Add(value2);
            var arr = fl1.ToArray();
            
            Assert.AreEqual(fl1.capacity - (fl1.capacity - fl1.length), arr.Length);
        }
        
        #endregion

        #region IntFastList

        [Test]
        [Category("IntFastList")]
        public void IntFastList_Ctor() {
            Assert.DoesNotThrow(() => {
                var ifl = new IntFastList();
            });
        }
        
        [Test]
        [Category("IntFastList")]
        [TestCase(30)]
        public void IntFastList_Ctor_With_Capacity(int capacity) {
            var ifl = new IntFastList(capacity);
            
            Assert.AreEqual(63, ifl.capacity);
        }
        
        [Test]
        [Category("IntFastList")]
        public void IntFastList_Other() {
            var ifl1 = new IntFastList();
            ifl1.Add(1);
            ifl1.Add(2);
            
            var ifl2 = new IntFastList(ifl1);
            
            Assert.AreEqual(ifl1, ifl2);
        }

        #endregion

        #region IntFastListExtensions
        [Test]
        [Category("IntFastListExtensions")]
        public void IntFastList_Add() {
            var ifl = new IntFastList();
            ifl.Add();
            ifl.Add();
            
            Assert.AreEqual(2, ifl.length);
        }
        
        [Test]
        [Category("IntFastListExtensions")]
        [TestCase(1,2)]
        public void IntFastList_Add_Value(int val1, int val2) {
            var ifl = new IntFastList();
            ifl.Add(val1);
            ifl.Add(val2);
            
            Assert.True(ifl.length == 2 && ifl.data[1] == val2);
        }
        
        [Test]
        [Category("IntFastListExtensions")]
        [TestCase(1)]
        public void IntFastList_Get(int val1) {
            var ifl = new IntFastList();
            ifl.Add(val1);
            var val = ifl.Get(0);
            
            Assert.AreEqual(val1, val);
        }
        
        [Test]
        [Category("IntFastListExtensions")]
        [TestCase(1, 2)]
        public void IntFastList_Set(int val1, int val2) {
            var ifl = new IntFastList();
            ifl.Add(val1);
            ifl.Set(0, val2);
            
            Assert.AreEqual(val2, ifl.data[0]);
        }
        
        [Test]
        [Category("IntFastListExtensions")]
        [TestCase(1, 2)]
        public void IntFastList_Add_List_Range(int val1, int val2) {
            var ifl1 = new IntFastList();
            ifl1.Add(val1);
            ifl1.Add(val2);

            var ifl2 = new IntFastList();
            ifl2.AddListRange(ifl1);
            
            Assert.AreEqual(2, ifl2.length);
        }
        
        [Test]
        [Category("IntFastListExtensions")]
        [TestCase(1, 2)]
        public void IntFastList_Swap(int val1, int val2) {
            var ifl1 = new IntFastList(); //TODO: fix
            Assert.Fail();
        }
        
        [Test]
        [Category("IntFastListExtensions")]
        [TestCase(1, 2)]
        public void IntFastList_Index_Of(int val1, int val2) {
            var ifl = new IntFastList();
            ifl.Add(val1);
            ifl.Add(val2);

            var index = ifl.IndexOf(val2);

            Assert.AreEqual(1, index);
        }
        
        [Test]
        [Category("IntFastListExtensions")]
        [TestCase(1, 2)]
        public void IntFastList_Remove(int val1, int val2) {
            var ifl = new IntFastList();
            ifl.Add(val1);
            ifl.Add(val2);
            ifl.Remove(val2);

            Assert.AreEqual(1, ifl.length);
        }
        
        [Test]
        [Category("IntFastListExtensions")]
        [TestCase(1, 2)]
        public void IntFastList_RemoveSwap(int val1, int val2) {
            var ifl = new IntFastList();
            ifl.Add(val1);
            ifl.Add(val2);

            var result = new IntFastList.ResultSwap();
            ifl.RemoveSwap(val1, out result);

            Assert.AreEqual(2, ifl.data[0]);
        }
        
        [Test]
        [Category("IntFastListExtensions")]
        [TestCase(1, 2)]
        public void IntFastList_Clear(int val1, int val2) {
            var ifl = new IntFastList();
            ifl.Add(val1);
            ifl.Add(val2);
            ifl.Clear();
            
            Assert.AreEqual(0, ifl.length);
        }
        
        [Test]
        [Category("FastListExtensions")]
        [TestCase(2,1)]
        public void IntFastList_Sort(int value1, int value2) {
            var fl1 = new IntFastList();
            
            fl1.Add(value1);
            fl1.Add(value2);
            fl1.Sort();

            Assert.AreEqual(1, fl1.data[0]);
        }
        
        [Test]
        [Category("FastListExtensions")]
        [TestCase(2,1)]
        public void IntFastList_Sort_By_Index_And_Len(int value1, int value2) {
            var fl1 = new IntFastList();
            
            fl1.Add(value1);
            fl1.Add(value2);
            fl1.Sort(0, 2);
            
            Assert.AreEqual(1, fl1.data[0]);
        }
        
        [Test]
        [Category("IntFastListExtensions")]
        [TestCase(1,2)]
        public void IntFastList_To_Array(int value1, int value2) {
            var fl1 = new IntFastList();
            
            fl1.Add(value1);
            fl1.Add(value2);
            var arr = fl1.ToArray();
            
            Assert.AreEqual(fl1.capacity - (fl1.capacity - fl1.length), arr.Length);
        }
        #endregion

        #region HashHelpers

        [Test]
        [Category("HashExtensions")]
        [TestCase(120)]
        public void Hash_Expand_Capacity(int oldSize) {
            var newCapacity = HashHelpers.ExpandCapacity(oldSize);
            
            Assert.AreEqual(255, newCapacity);
        }
        
        [Test]
        [Category("HashExtensions")]
        [TestCase(30)]
        public void Hash_Get_Capacity(int min) {
            var capacity = HashHelpers.GetCapacity(min);
            
            Assert.AreEqual(63, capacity);
        }

        #endregion
    }
}