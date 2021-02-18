require './dtm'

tape = Tape.new(['1', '0', '1'], '1', [], '_')
p tape

p tape.move_head_left
p tape.write('0')
p tape.move_head_right
p tape.move_head_right.write('0')

p '-------------TMRule--------------'

rule = TMRule.new(1, '0', 2, '1', :right)
p rule

p rule.applies_to?(TMConfiguration.new(1, Tape.new([], '0', [], '_')))
p rule.applies_to?(TMConfiguration.new(1, Tape.new([], '1', [], '_')))
p rule.applies_to?(TMConfiguration.new(2, Tape.new([], '0', [], '_')))

p rule.follow(TMConfiguration.new(1, Tape.new([], '0', [], '_')))

p '-------------DTMRulebook---------------'

rulebook = DTMRulebook.new([
  TMRule.new(1, '0', 2, '1', :right),
  TMRule.new(1, '1', 1, '0', :left),
  TMRule.new(1, '_', 2, '1', :right),
  TMRule.new(2, '0', 2, '0', :right),
  TMRule.new(2, '1', 2, '1', :right),
  TMRule.new(2, '_', 3, '_', :left),
])

p rulebook

configuration = TMConfiguration.new(1, tape)
p configuration = rulebook.next_configuration(configuration)
p configuration = rulebook.next_configuration(configuration)
p configuration = rulebook.next_configuration(configuration)

p '-------------DTM----------------------'

dtm = DTM.new(TMConfiguration.new(1, tape), [3], rulebook)
p dtm.current_configuration
p dtm.accepting?

dtm.step
p dtm.current_configuration
p dtm.accepting?

dtm.run
p dtm.current_configuration
p dtm.accepting?

p '------------aaabbbcccを認識するdtm-------------'

rulebook = DTMRulebook.new([
  # 状態1: aを探して右にスキャンする
  TMRule.new(1, 'X', 1, 'X', :right), # Xをスキップする
  TMRule.new(1, 'a', 2, 'X', :right), # aを消して、状態2に進む
  TMRule.new(1, '_', 6, '_', :left),  # 空白を見つけて、状態6(受理状態)に進む

  # 状態2: bを探して右にスキャンする
  TMRule.new(2, 'a', 2, 'a', :right), # aをスキップする
  TMRule.new(2, 'X', 2, 'X', :right), # Xをスキップする
  TMRule.new(2, 'b', 3, 'X', :right), # bを消して、状態3に進む

  # 状態3: cを探して右にスキャンする
  TMRule.new(3, 'b', 3, 'b', :right), # bをスキップする
  TMRule.new(3, 'X', 3, 'X', :right), # Xをスキップする
  TMRule.new(3, 'c', 4, 'X', :right), # cを消して、状態4に進む

  # 状態4: 文字列の末尾を探して右にスキャンする
  TMRule.new(4, 'c', 4, 'c', :right), # cをスキップする
  TMRule.new(4, '_', 5, '_', :left),  # 空白を見つけて、状態5に進む

  # 状態5: 文字列の先頭を探して左にスキャンする
  TMRule.new(5, 'a', 5, 'a', :left),  # aをスキップする
  TMRule.new(5, 'b', 5, 'b', :left),  # bをスキップする
  TMRule.new(5, 'c', 5, 'c', :left),  # cをスキップする
  TMRule.new(5, 'X', 5, 'X', :left),  # Xをスキップする
  TMRule.new(5, '_', 1, '_', :right), # 空白を見つけて、状態1に進む
])

tape = Tape.new([], 'a', %w(a a b b b c c c), '_')
p tape

dtm = DTM.new(TMConfiguration.new(1, tape), [6], rulebook)
10.times {dtm.step}
p dtm.current_configuration
25.times {dtm.step}
p dtm.current_configuration

dtm.run
p dtm.current_configuration
